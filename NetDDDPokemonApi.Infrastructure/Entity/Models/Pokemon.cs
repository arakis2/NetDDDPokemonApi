using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDDDPokemonApi.Infrastructure.Entity.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Pokemon : DbBase
    {
        public Pokemon() 
        {
            Types = new List<Type>();
        }       
        public string? Name { get; set; }
        public string? Hp { get; set; }
        public string? Cp { get; set;}
        public string? Picture { get; set; }

        public IEnumerable<Type> Types { get; set; }
    }
}
