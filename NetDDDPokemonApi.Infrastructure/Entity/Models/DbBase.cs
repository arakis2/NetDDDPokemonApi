﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDDDPokemonApi.Infrastructure.Entity.Models
{
    public class DbBase
    {
        [Key]
        public long Id { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set;}
    }
}
