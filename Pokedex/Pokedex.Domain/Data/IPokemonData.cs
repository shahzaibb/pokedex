using System;
namespace Pokedex.Domain.Data
{
	public interface IPokemonData
	{
		Task<PokemonModel> GetPokemonAsync(string name);
	}
}

