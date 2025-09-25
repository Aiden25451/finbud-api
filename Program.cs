using FinbudApi.Contracts;
using FinbudApi.Models;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Supabase.Client>(_ => 
    new Supabase.Client(
        builder.Configuration["Supabase:Url"] ?? throw new InvalidOperationException("Supabase URL is not configured."),
        builder.Configuration["Supabase:Key"] ?? throw new InvalidOperationException("Supabase Key is not configured."),
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/monkeys", async (
    CreateMonkeyRequest request,
    Supabase.Client client) =>
    {
        var monkey = new Monkey
        {
            Name = request.Name,
            Type = request.Type,
            Age = request.Age,
        };

        var response = await client.From<Monkey>().Insert(monkey);

        var newMonkey = response.Models.First();

        return Results.Ok(newMonkey.Id);
    }
);

app.MapGet("/monkeys/{id}", async (long id, Supabase.Client client) =>
{
    var response = await client
        .From<Monkey>()
        .Where(n => n.Id == id)
        .Get();

    var monkey = response.Models.FirstOrDefault();

    if (monkey == null)
    {
        return Results.NotFound();
    }

    var monkeyResponse = new MonkeyResponse
    {
        Id = monkey.Id,
        Name = monkey.Name,
        Type = monkey.Type,
        Age = monkey.Age,
        CreatedAt = monkey.CreatedAt
    };

    return Results.Ok(monkeyResponse);
});

app.MapDelete("/monkeys/{id}", async (long id, Supabase.Client client) =>
{
    await client
        .From<Monkey>()
        .Where(n => n.Id == id)
        .Delete();

    return Results.NoContent();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();