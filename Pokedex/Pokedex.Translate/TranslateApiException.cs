using System;
namespace Pokedex.Translate
{
	public class TranslateApiException : Exception
	{
		public TranslateApiException()
		{
		}

		public TranslateApiException(string message) : base(message) { }
	}
}

