
using Microsoft.EntityFrameworkCore;

namespace NetDDDPokemonApi.Infrastructure.Entity.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User : DbBase
    {
        public string? UserName { get; set; }
        public string? Password { get; set;}
    }
}
