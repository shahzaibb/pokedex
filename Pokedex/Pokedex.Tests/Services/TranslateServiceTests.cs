using System;
using System.Threading.Tasks;
using Moq;
using Pokedex.Domain.Models;
using Pokedex.Domain.Services;
using Pokedex.Translate;
using Xunit;

namespace Pokedex.Tests.Services
{
	public class TranslateServiceTests
	{
		private readonly TranslateService _translateService;

		public TranslateServiceTests(TranslateService translateService)
		{
			_translateService = translateService;
		}

		[Fact]
		public async Task TranslateTextAsync_Valid()
		{
			var result = await _translateService.TranslateTextAsync(It.IsAny<TranslateType>(), It.IsAny<string>());

			Assert.NotNull(result);
		}

		[Fact]
		public async Task TranslateTextAsync_Invalid()
		{
			await Assert.ThrowsAsync<TranslateApiException>(() => _translateService.TranslateTextAsync(It.IsAny<TranslateType>(), It.IsAny<string>()));
		}
	}
}

