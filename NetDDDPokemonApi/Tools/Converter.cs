using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Entity.Models;

namespace NetDDDPokemonApi.Tools
{
    public static class Converter
    {
        public static PokemonModel ToPokemonModel(this Pokemon pokemon)
        {
            return new PokemonModel
            {
                Cp = pokemon.Cp,
                Created = pokemon.Created ?? DateTime.Now,
                Hp = pokemon.Hp,
                Id = pokemon.Id,
                Name = pokemon.Name,
                Picture = pokemon.Picture,
                Types = pokemon.Types.Where(t => t != null && !string.IsNullOrWhiteSpace(t.Name)).Select(t => t.Name).OrderBy(n => n).ToList(),
                Updated = pokemon.Updated
            };
        }

        public static List<PokemonModel> ToPokemonModels(this List<Pokemon> pokemons)
        {
            var pokemonModels = new List<PokemonModel>();

            foreach (var pokemon in pokemons)
            {
                pokemonModels.Add(pokemon.ToPokemonModel());
            }

            return pokemonModels;
        }
    }
}
