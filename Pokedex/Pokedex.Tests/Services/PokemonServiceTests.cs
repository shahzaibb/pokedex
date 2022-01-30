using System;
using System.Threading.Tasks;
using Moq;
using Pokedex.Domain;
using Pokedex.Domain.Data;
using Pokedex.Services;
using Xunit;

namespace Pokedex.Tests.Services
{
	public class PokemonServiceTests
	{
		private readonly Mock<IPokemonData> _pokemonData;
		private readonly PokemonService _service;

		public PokemonServiceTests()
		{
			_pokemonData = new Mock<IPokemonData>();
			_service = new PokemonService(_pokemonData.Object);
		}

		[Fact]
		public async Task GetPokemonAsync_Exists()
		{
			var name = "pokemon";
			_pokemonData.Setup(x => x.GetPokemonAsync(It.IsAny<string>())).ReturnsAsync((string name) =>
			{
				return new PokemonModel { Name = name };
			});
			
			var result = await _service.GetPokemonAsync(name);

			Assert.NotNull(result);
			Assert.IsType<PokemonModel>(result);
			Assert.Equal(name, result.Name);
			_pokemonData.Verify(x => x.GetPokemonAsync(It.IsAny<string>()), Times.Once);
			_pokemonData.VerifyNoOtherCalls();
		}

		[Fact]
		public async Task GetPokemonAsync_NotExists()
		{
			var name = "pokemon";
			_pokemonData.Setup(x => x.GetPokemonAsync(It.IsAny<string>())).ReturnsAsync((PokemonModel)null);

			var result = await _service.GetPokemonAsync(name);

			Assert.Null(result);
			_pokemonData.Verify(x => x.GetPokemonAsync(It.IsAny<string>()), Times.Once);
			_pokemonData.VerifyNoOtherCalls();
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