using System;
using Pokedex.Domain;
using Pokedex.Domain.Services;

namespace Pokedex.Services
{
	public class PokemonService : IPokemonService
	{
		public PokemonService()
		{
		}

        public Task<PokemonModel> GetPokemonAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}

