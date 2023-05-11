using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Infrastructure.Entity;
using System.Text.Unicode;

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
            await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE \"{nomTable}\" RESTART IDENTITY CASCADE;");
        }
    }
}
