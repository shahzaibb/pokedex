using System;
using Pokedex.Domain;
using Pokedex.Domain.Data;
using Pokedex.Domain.Models;
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

        public async Task<PokemonModel> GetPokemonTranslatedAsync(string name)
        {
            var pokemon = await GetPokemonAsync(name);

            if (pokemon == null)
                return null;

            var translationType = pokemon.Habitat?.ToLowerInvariant() == "cave" || pokemon.IsLegendary
                ? TranslateType.Yoda : TranslateType.Shakespeare;

            try
            {
                var translatedText = await _translateService.TranslateTextAsync(translationType, pokemon?.Description);
                if (!string.IsNullOrEmpty(translatedText))
                    pokemon.Description = translatedText;
            }
            catch (TranslateApiException)
            {
                //3. If vou can't translate the Pokemons descriotion (for whatever reason t) then use the standard descriotior
            }

            return pokemon;
        }
    }
}

