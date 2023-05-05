using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDDDPokemonApi.Domain.models
{
    public class TypeModel : ModelBase
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
