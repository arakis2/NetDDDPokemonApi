using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDDDPokemonApi.Infrastructure.Entity.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Type : DbBase
    {
        public string? Name { get; set; }
    }
}
