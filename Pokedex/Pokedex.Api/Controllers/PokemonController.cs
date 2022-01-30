using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{    
    public PokemonController()
    {
        
    }

    [HttpGet("{name}", Name = nameof(GetPokemon))]
    public ActionResult<Pokemon> GetPokemon(string name)
    {
        throw new NotImplementedException();
    }
}

