using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pokedex.Api;
using Pokedex.Api.Controllers;
using Pokedex.Domain;
using Pokedex.Domain.Services;
using Xunit;

namespace Pokedex.Tests.Controllers
{
	public class PokemonControllerTests
	{
		private readonly Mock<IPokemonService> _pokemonService;
		private readonly PokemonController _controller;

		public PokemonControllerTests()
		{
			_pokemonService = new Mock<IPokemonService>();
			_controller = new PokemonController(_pokemonService.Object);
		}

		[Fact]
		public async Task GetPokemon_Ok()
        {
			_pokemonService.Setup(x => x.GetPokemonAsync(It.IsAny<string>()))
				.ReturnsAsync(new PokemonModel());

			var result = await _controller.GetPokemon(It.IsAny<string>());

			Assert.IsType<OkObjectResult>(result.Result);
			var objectResult = result.Result as OkObjectResult;
			Assert.IsAssignableFrom<Pokemon>(objectResult.Value);
			_pokemonService.Verify(x => x.GetPokemonAsync(It.IsAny<string>()), Times.Once);
			_pokemonService.VerifyNoOtherCalls();
		}

		[Fact]
		public async Task GetPokemon_NotFound()
		{
			_pokemonService.Setup(x => x.GetPokemonAsync(It.IsAny<string>()))
				.ReturnsAsync((PokemonModel)null);

			var result = await _controller.GetPokemon(It.IsAny<string>());

			Assert.IsType<NotFoundObjectResult>(result.Result);
			_pokemonService.Verify(x => x.GetPokemonAsync(It.IsAny<string>()), Times.Once);
			_pokemonService.VerifyNoOtherCalls();
		}


		[Fact]
		public async Task GetTranslatedPokemon_Ok()
		{
			_pokemonService.Setup(x => x.GetPokemonTranslatedAsync(It.IsAny<string>()))
				.ReturnsAsync(new PokemonModel());

			var result = await _controller.GetPokemonTranslated(It.IsAny<string>());

			Assert.IsType<OkObjectResult>(result.Result);
			var objectResult = result.Result as OkObjectResult;
			Assert.IsAssignableFrom<Pokemon>(objectResult.Value);
			_pokemonService.Verify(x => x.GetPokemonTranslatedAsync(It.IsAny<string>()), Times.Once);
			_pokemonService.VerifyNoOtherCalls();
		}

		[Fact]
		public async Task GetTranslatedPokemon_NotFound()
		{
			_pokemonService.Setup(x => x.GetPokemonTranslatedAsync(It.IsAny<string>()))
				.ReturnsAsync((PokemonModel)null);

			var result = await _controller.GetPokemonTranslated(It.IsAny<string>());

			Assert.IsType<NotFoundObjectResult>(result.Result);
			_pokemonService.Verify(x => x.GetPokemonTranslatedAsync(It.IsAny<string>()), Times.Once);
			_pokemonService.VerifyNoOtherCalls();
		}
	}
}

