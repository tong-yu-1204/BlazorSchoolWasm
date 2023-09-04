var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors();
var app = builder.Build();


// Configure the HTTP request pipeline
string[] summaries = new[]
{
    "Freezing","Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20,55),
            summaries[Random.Shared.Next(summaries.Length)]
            )
    ).ToArray();
    return forecast;
});

app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod());
app.Run();


internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int temperatureF => 32 + (int)(TemperatureC / 0.5556);

}
