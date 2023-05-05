using NetDDDPokemonApi.Domain.models;
using Newtonsoft.Json;

namespace NetDDDPokemonApi.models
{
    public class DataModel
    {
        [JsonProperty("pokemons")]
        public List<PokemonModel>? Pokemons { get; set; }
        [JsonProperty("types")]
        public List<TypeModel>? Types { get; set; }
        [JsonProperty("users")]
        public List<UserModel>? Users { get; set; }
    }
}
