using System;
namespace Pokedex.Domain.Services
{
	public interface IPokemonService
	{
		Task<PokemonModel> GetPokemonAsync(string name);

		Task<PokemonModel> GetPokemonTranslatedAsync(string name);
	}
}

