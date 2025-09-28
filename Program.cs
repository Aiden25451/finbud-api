using FinbudApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerServices();

}

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddControllers();
builder.Services.AddSupabase(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddAuth0(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();