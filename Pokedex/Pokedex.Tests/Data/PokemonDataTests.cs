using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Pokedex.Data;
using Pokedex.Domain;
using Xunit;

namespace Pokedex.Tests.Data
{
	public class PokemonDataTests
	{
		private readonly PokemonData _data;
		private readonly HttpClient _httpClient;
		private readonly MockHttpMessageHandler _mockHttpMessageHandler;

		public PokemonDataTests()
		{
			_mockHttpMessageHandler = new MockHttpMessageHandler();
			_httpClient = new HttpClient(_mockHttpMessageHandler.Object);
			_data = new PokemonData(_httpClient);
			_httpClient.BaseAddress = new Uri("https://mockserver.com");
		}

		[Fact]
		public async Task GetPokemonAsync_Exists()
		{
			var pokemonData = await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}/SampleData/pokemon-species.json");

			var response = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent(pokemonData)
			};
			_mockHttpMessageHandler.CreatMockMessageHandler(response);

			var name = "ditto";
			var result = await _data.GetPokemonAsync(name);

			Assert.NotNull(result);
			Assert.IsType<PokemonModel>(result);
			Assert.Equal(name, result.Name);			
		}

		[Fact]
		public async Task GetPokemonAsync_NotExists()
		{
			var response = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.NotFound
			};
			_mockHttpMessageHandler.CreatMockMessageHandler(response);

			var result = await _data.GetPokemonAsync(It.IsAny<string>());
			Assert.Null(result);
		}
	}
}

