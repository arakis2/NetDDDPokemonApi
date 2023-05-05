using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Infrastructure.Entity;

namespace NetDDDPokemonApi.Infrastructure.Services
{
    public class Dbservice
    {
        public readonly PokemonDbContext dbContext;

        public Dbservice(PokemonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task TruncateTableAsync(string nomTable)
        {
            await dbContext.Database.ExecuteSqlAsync($"TRUNCATE TABLE {nomTable}");
        }
    }
}
