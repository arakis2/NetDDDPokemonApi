using Newtonsoft.Json;

namespace NetDDDPokemonApi.Domain.models
{
    public class PokemonModel : ModelBase
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("hp")]
        public string? Hp { get; set; }

        [JsonProperty("cp")]
        public string? Cp { get; set;}

        [JsonProperty("picture")]
        public string? Picture { get; set; }

        [JsonProperty("types")]
        public List<string>? Types { get; set; }
    }
}
