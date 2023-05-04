using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Entity.Models;
using NetDDDPokemonApi.Infrastructure.Interfaces;

namespace NetDDDPokemonApi.Infrastructure.Services
{
    public class PokemonDbService : Dbservice, IDbService, IPokemonDbService
    {
        public const string POKEMONS = "Pokemons";
        public PokemonDbService(PokemonDbContext context) : base(context) { } 

        public async Task<List<Pokemon>> GetPokemonsAsync()
        {
            return await dbContext.Set<Pokemon>()
                .AsNoTracking()
                //.Include(t => t.Types)
                .ToListAsync();
        }

        public async Task<Pokemon?> GetPokemonByIdAsync(long id)
        {
            return await dbContext.Set<Pokemon>()
                .AsNoTracking()
                .Include(t => t.Types)
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon)
        {
            dbContext.Pokemons.Attach(pokemon);
            dbContext.Pokemons.Update(pokemon);

            await dbContext.SaveChangesAsync();

            return pokemon;
        }

        public async Task DeletePokemonAsync(Pokemon pokemon)
        {
            dbContext.Pokemons.Remove(pokemon);
            await dbContext.SaveChangesAsync();

        }

        public async Task TruncateTable()
        {
            await TruncateTable(POKEMONS);
        }
    }
}
