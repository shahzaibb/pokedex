using System;
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

		public PokemonDataTests()
		{
			_data = new PokemonData();
		}

		[Fact]
		public async Task GetPokemonAsync_Exists()
		{
			var name = "pokemon";
			var result = await _data.GetPokemonAsync(name);
			Assert.NotNull(result);
			Assert.IsType<PokemonModel>(result);
			Assert.Equal(name, result.Name);
		}

		[Fact]
		public async Task GetPokemonAsync_NotExists()
		{
			var result = await _data.GetPokemonAsync(It.IsAny<string>());
			Assert.Null(result);
		}
	}
}

