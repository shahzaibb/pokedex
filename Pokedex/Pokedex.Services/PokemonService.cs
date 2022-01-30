using System;
using Pokedex.Domain;
using Pokedex.Domain.Data;
using Pokedex.Domain.Services;

namespace Pokedex.Services
{
	public class PokemonService : IPokemonService
	{
        private readonly IPokemonData _pokemonData;

		public PokemonService(IPokemonData pokemonData)
		{
            _pokemonData = pokemonData;

        }

        public Task<PokemonModel> GetPokemonAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Pokemon name is required");

            return _pokemonData.GetPokemonAsync(name);
        }
    }
}

