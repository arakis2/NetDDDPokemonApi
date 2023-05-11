using Microsoft.EntityFrameworkCore;


namespace NetDDDPokemonApi.Infrastructure.Entity.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Type : DbBase
    {
        public string? Name { get; set; }

        public IEnumerable<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
