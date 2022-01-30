using System;
using System.Net;
using Newtonsoft.Json;
using Pokedex.Domain;
using Pokedex.Domain.Data;

namespace Pokedex.Data
{
	public class PokemonData : IPokemonData
	{
        private readonly HttpClient _httpClient;
        private const string speciesEndpointPath = "pokemon-species";

        public PokemonData(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task<PokemonModel> GetPokemonAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{speciesEndpointPath}/{name}");
                var species = JsonConvert.DeserializeObject<PokemonSpeciesEntity>(response);

                if (species == null)
                    throw new NullReferenceException($"Empty data returned for: {name}");

                return species.ToModel();
            }
            catch(HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    return null;

                throw e;
            }            
        }
    }
}

