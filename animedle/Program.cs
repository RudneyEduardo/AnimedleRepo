using animedle.Models;
using animedle.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AnimeDbSettings>(
    builder.Configuration.GetSection("animedle"));

builder.Services.AddSingleton<AnimeService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().
        AddJsonOptions(
            options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

// Disable CORS since angular will be running on port 4200 and the service on port 5258.
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();