using System;
using Pokedex.Domain.Models;
using Pokedex.Domain.Services;

namespace Pokedex.Translate
{
	public class TranslateService : ITranslateService
	{
        private readonly HttpClient _httpClient;

		public TranslateService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public Task<string> TranslateTextAsync(TranslateType type, string text)
        {
            throw new NotImplementedException();
        }
    }
}

