using Microsoft.AspNetCore.Mvc;
using Pokedex.Domain.Services;

namespace Pokedex.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet("{name}", Name = nameof(GetPokemon))]
    public async Task<ActionResult<Pokemon>> GetPokemon(string name)
    {
        var result = await _pokemonService.GetPokemonAsync(name);

        if (result == null)
            return NotFound($"Pokmon {name} not found");

        return Ok(Pokemon.FromModel(result));
    }

    [HttpGet("translated/{name}", Name = nameof(GetPokemonTranslated))]
    public async Task<ActionResult<Pokemon>> GetPokemonTranslated(string name)
    {
        var result = await _pokemonService.GetPokemonTranslatedAsync(name);

        if (result == null)
            return NotFound($"Pokmon {name} not found");

        return Ok(Pokemon.FromModel(result));
    }
}

