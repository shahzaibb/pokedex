using System;
using System.Net;
using Newtonsoft.Json;
using Pokedex.Domain.Models;
using Pokedex.Domain.Services;
using Pokedex.Translate.Models;

namespace Pokedex.Translate
{
	public class TranslateService : ITranslateService
	{
        private readonly HttpClient _httpClient;

		public TranslateService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task<string> TranslateTextAsync(TranslateType type, string text)
        {
            var url = type == TranslateType.Shakespeare ? "shakespeare" : "yoda";
            var query = new StringContent($"text={text}");

            var result = await _httpClient.PostAsync(url, query);

            if (result.StatusCode != HttpStatusCode.OK)
                throw new TranslateApiException($"{result.StatusCode} : Translateion api erroe");

            var translation = JsonConvert.DeserializeObject<Translation>(await result.Content.ReadAsStringAsync());

            return translation?.contents?.translated;
        }
    }
}

