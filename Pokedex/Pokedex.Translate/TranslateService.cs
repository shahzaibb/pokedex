using System;
using Pokedex.Domain.Services;

namespace Pokedex.Translate
{
	public class TranslateService : ITranslateService
	{
		public TranslateService()
		{
		}

        public Task<string> TranslateTextAsync(string text)
        {
            throw new NotImplementedException();
        }
    }
}

