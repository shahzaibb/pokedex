using Pokedex.Data;
using Pokedex.Domain.Data;
using Pokedex.Domain.Services;
using Pokedex.Services;
using Pokedex.Translate;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddHttpClient<IPokemonData, PokemonData>((client) => { client.BaseAddress = new Uri(config["PokeApi"]); });
builder.Services.AddHttpClient<ITranslateService, TranslateService>((client) => { client.BaseAddress = new Uri(config["TranslationApi"]); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

