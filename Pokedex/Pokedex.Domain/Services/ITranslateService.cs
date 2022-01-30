using System;
using Pokedex.Domain.Models;

namespace Pokedex.Domain.Services
{
	public interface ITranslateService
	{
		Task<string> TranslateTextAsync(TranslateType type, string text);
	}
}

