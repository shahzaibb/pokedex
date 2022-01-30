using System;
using System.Threading.Tasks;
using Moq;
using Pokedex.Domain;
using Pokedex.Services;
using Xunit;

namespace Pokedex.Tests.Services
{
	public class PokemonServiceTests
	{
		private readonly PokemonService _service;

		public PokemonServiceTests()
		{
			_service = new PokemonService();
		}

		[Fact]
		public async Task GetPokemonAsync_Exists()
		{
			var name = "pokemon";
			var result = await _service.GetPokemonAsync(name);
			Assert.NotNull(result);
			Assert.IsType<PokemonModel>(result);
			Assert.Equal(name, result.Name);
		}

		[Fact]
		public async Task GetPokemonAsync_NotExists()
		{
			var result = await _service.GetPokemonAsync(It.IsAny<string>());
			Assert.Null(result);
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public async Task GetPokemonAsync_InvalidArgument(string name)
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetPokemonAsync(name));
		}
	}
}