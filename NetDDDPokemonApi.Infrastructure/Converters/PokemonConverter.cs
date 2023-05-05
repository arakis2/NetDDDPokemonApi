using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Entity.Models;

namespace NetDDDPokemonApi.Infrastructure.Converters
{
    public static class PokemonConverter
    {
        public static PokemonModel? ToModel(this Pokemon? pokemon)
        {
            if (pokemon == null) return null;

            return new PokemonModel
            {
                Cp = pokemon.Cp,
                Created = pokemon.Created,
                Hp = pokemon.Hp,
                Id = pokemon.Id,
                Name = pokemon.Name,
                Picture = pokemon.Picture,
                Types = pokemon.Types.ToListString(),
                Updated = pokemon.Updated,
            };
        }

        public static Pokemon? ToPokemon(this PokemonModel? model, List<TypeModel> types)
        {
            if (model == null) return null;

            types = types ?? throw new ArgumentNullException(nameof(types));

            return new Pokemon
            {
                Cp = model.Cp,
                Created = model.Created,
                Hp = model.Hp,
                Id = model.Id,
                Name = model.Name,
                Picture= model.Picture,
                Types = types.ToTypes(),
                Updated = model.Updated
            };
        }

        public static List<PokemonModel> ToModels(this List<Pokemon> pokemons)
        {
            var models = new List<PokemonModel>();

            foreach (var pokemon in pokemons)
            {
                var model = pokemon.ToModel();

                if(model != null) models.Add(model);
            }

            return models;
        }

        public static List<Pokemon> ToPokemons(this Dictionary<PokemonModel, List<TypeModel>> dict)
        {
            var pokemons = new List<Pokemon>();

            foreach (var row in dict)
            {
                var pokemon = row.Key.ToPokemon(row.Value);
               if(pokemon != null) pokemons.Add(pokemon);
            }

            return pokemons;
        }
    }
}
