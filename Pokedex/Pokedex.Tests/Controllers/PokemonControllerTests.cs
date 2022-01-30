using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pokedex.Api.Controllers;
using Xunit;

namespace Pokedex.Tests.Controllers
{
	public class PokemonControllerTests
	{
		private readonly PokemonController _controller;

		public PokemonControllerTests()
		{
			_controller = new PokemonController();
		}

		[Fact]
		public void GetPokemon_Ok()
        {
			var result = _controller.GetPokemon(It.IsAny<string>());

			Assert.IsType<OkObjectResult>(result);
        }

		[Fact]
		public void GetPokemon_NotFound()
		{
			var result = _controller.GetPokemon(It.IsAny<string>());

			Assert.IsType<NotFoundObjectResult>(result);
		}
	}
}

