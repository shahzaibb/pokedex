using System;
using Pokedex.Domain;
using Pokedex.Domain.Data;

namespace Pokedex.Data
{
	public class PokemonData : IPokemonData
	{
		public PokemonData()
		{
		}

        public Task<PokemonModel> GetPokemonAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}

