using System;
namespace Pokedex.Domain.Services
{
	public interface ITranslateService
	{
		Task<string> TranslateTextAsync(string text);
	}
}

