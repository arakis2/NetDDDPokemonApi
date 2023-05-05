using System;
using System.ComponentModel.DataAnnotations;

namespace NetDDDPokemonApi.Infrastructure.Entity.Models
{
    public class DbBase
    {
        [Key]
        public long? Id { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set;}
    }
}
