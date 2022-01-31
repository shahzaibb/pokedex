using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Pokedex.Domain;
using Pokedex.Domain.Models;
using Pokedex.Translate;
using Pokedex.Translate.Models;
using Xunit;

namespace Pokedex.Tests.Services
{
    public class TranslateServiceTests
	{
		private readonly HttpClient _httpClient;
		private readonly MockHttpMessageHandler _mockHttpMessageHandler;
		private readonly TranslateService _translateService;

		public TranslateServiceTests()
		{
			_mockHttpMessageHandler = new MockHttpMessageHandler();
			_httpClient = new HttpClient(_mockHttpMessageHandler.Object);
			_httpClient.BaseAddress = new Uri("https://mockserver.com");
			_translateService = new TranslateService(_httpClient);
		}

		[Fact]
		public async Task TranslateTextAsync_Valid()
		{
			var sample = "sample translation";
			var translation = JsonConvert.SerializeObject(new Translation() { contents = new Contents { translated = sample } });
			var response = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent(translation)
			};
			_mockHttpMessageHandler.CreatMockMessageHandler(response);

			var result = await _translateService.TranslateTextAsync(It.IsAny<TranslateType>(), It.IsAny<string>());

			Assert.NotNull(result);
			Assert.Equal(sample, result);
		}

		[Fact]
		public async Task TranslateTextAsync_Invalid()
		{
			var response = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.BadRequest
			};
			_mockHttpMessageHandler.CreatMockMessageHandler(response);

			await Assert.ThrowsAsync<TranslateApiException>(() => _translateService.TranslateTextAsync(It.IsAny<TranslateType>(), It.IsAny<string>()));
		}		
	}
}

