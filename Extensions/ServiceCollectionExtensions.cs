using System.Security.Claims;
using FinbudApi.Authorization;
using FinbudApi.Data;
using FinbudApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Supabase;

namespace FinbudApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSupabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<Supabase.Client>(_ =>
            new Supabase.Client(
                configuration["Supabase:Url"] ?? throw new InvalidOperationException("Supabase URL is not configured."),
                configuration["Supabase:Key"] ?? throw new InvalidOperationException("Supabase Key is not configured."),
                new SupabaseOptions
                {
                    AutoRefreshToken = true,
                    AutoConnectRealtime = true
                })
        );

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<SupabaseDbContext>();
        services.AddScoped<IMonkeyService, MonkeyService>();
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IUserHistoryService, UserHistoryService>();
        services.AddScoped<IUserAchievementService, UserAchievementService>();


        // Add more services here as your app grows
        // services.AddScoped<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JWTToken_Auth_API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddAuth0(this IServiceCollection services, IConfiguration configuration)
    {
        var domain = $"https://{configuration["Auth0:Domain"]}/";
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = domain;
            options.Audience = configuration["Auth0:Audience"];
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimTypes.NameIdentifier
            };
        });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("read:messages", policy => policy.Requirements.Add(new
            HasScopeRequirement("read:messages", domain)));
        });
        services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

        return services;
    }
}