
using Newtonsoft.Json;

namespace NetDDDPokemonApi.Domain.models
{
    public class UserModel : ModelBase
    {
        [JsonProperty("username")]
        public string? UserName { get; set; }
        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
