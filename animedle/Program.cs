using animedle.Models;
using animedle.Services;
using animedle.Services.Interfaces;
using animedle.Repositories;
using animedle.Repositories.Interfaces; 

var builder = WebApplication.CreateBuilder(args);

// Configuração do MongoDB
builder.Services.Configure<AnimeDbSettings>(
    builder.Configuration.GetSection("AnimeDb"));

// Registro do repositório e service
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IAnimeService, AnimeService>();


// Configuração do Swagger e Controllers
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Build da aplicação
var app = builder.Build();

// Pipeline de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS e static files
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(builder =>
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
