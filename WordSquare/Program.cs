using WordSquare.Infrastructure;
using WordSquare.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DictionaryService>();
builder.Services.AddSingleton<BuildSquareService>();
builder.Services.AddSingleton<IDictionaryClient, DictionaryClient>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
