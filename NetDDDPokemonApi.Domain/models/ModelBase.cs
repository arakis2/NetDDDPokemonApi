using Newtonsoft.Json;

namespace NetDDDPokemonApi.Domain.models
{
    public class ModelBase
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("created")]
        public DateTime? Created { get; set; } = DateTime.UtcNow;

        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }
    }
}
