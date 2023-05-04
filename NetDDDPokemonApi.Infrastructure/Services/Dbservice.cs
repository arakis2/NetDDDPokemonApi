using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Interfaces;

namespace NetDDDPokemonApi.Infrastructure.Services
{
    public class Dbservice
    {
        public readonly PokemonDbContext dbContext;

        public Dbservice(PokemonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task TruncateTable(string nomTable)
        {
            await dbContext.Database.ExecuteSqlAsync($"TRUNCATE TABLE {nomTable}");
        }
    }
}
