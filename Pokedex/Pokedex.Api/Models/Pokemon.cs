using System;
using Pokedex.Domain;

namespace Pokedex.Api
{
	public class Pokemon
	{
		public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public bool IsLegendary { get; set; }

        public static Pokemon FromModel(PokemonModel model)
        {
            return new Pokemon
            {
                Name = model.Name,
                Description = model.Description,
                Habitat = model.Habitat,
                IsLegendary = model.IsLegendary
            };
        }
    }
}

