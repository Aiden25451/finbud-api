using FinbudApi.Data;
using FinbudApi.Services;
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

        // Add more services here as your app grows
        // services.AddScoped<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}