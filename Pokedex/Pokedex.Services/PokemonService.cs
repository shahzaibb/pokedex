using System;
using Pokedex.Domain;
using Pokedex.Domain.Data;
using Pokedex.Domain.Services;

namespace Pokedex.Services
{
	public class PokemonService : IPokemonService
	{
        private readonly IPokemonData _pokemonData;
        private readonly ITranslateService _translateService;

        public PokemonService(IPokemonData pokemonData, ITranslateService translateService)
		{
            _pokemonData = pokemonData;
            _translateService = translateService;
        }

        public Task<PokemonModel> GetPokemonAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Pokemon name is required");

            return _pokemonData.GetPokemonAsync(name);
        }

        public Task<PokemonModel> GetPokemonTranslatedAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}

