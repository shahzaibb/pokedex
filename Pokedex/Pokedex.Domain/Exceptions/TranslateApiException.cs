using System;
namespace Pokedex.Domain
{
	public class TranslateApiException : Exception
	{
		public TranslateApiException()
		{
		}

		public TranslateApiException(string message) : base(message) { }
	}
}

