﻿using Microsoft.EntityFrameworkCore;


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
