using System;
using System.Net;
using Newtonsoft.Json;
using Pokedex.Domain.Models;
using Pokedex.Domain.Services;
using Pokedex.Translate.Models;
using Pokedex.Domain;

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
            var content = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("text", text)
            });

            var result = await _httpClient.PostAsync(url, content);

            if (result.StatusCode != HttpStatusCode.OK)
                throw new TranslateApiException($"{result.StatusCode} : Translateion api error");

            var translation = JsonConvert.DeserializeObject<Translation>(await result.Content.ReadAsStringAsync());

            if (string.IsNullOrEmpty(translation?.contents?.translated))
                throw new TranslateApiException($"Translateion api returned blank for translation");

            return translation.contents.translated;
        }
    }
}

