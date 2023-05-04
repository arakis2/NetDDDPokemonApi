using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Interfaces;
using Type = NetDDDPokemonApi.Infrastructure.Entity.Models.Type;

namespace NetDDDPokemonApi.Infrastructure.Services
{
    internal class TypeDbService : Dbservice, IDbService, ITypeDbService
    {
        public const string TYPES = "Types";
        public TypeDbService(PokemonDbContext dbContext)
            :base(dbContext) { }
        
        public async Task<List<Type>> GetTypesAsync()
        {
            return await dbContext.Set<Type>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Type>> GetTypesByNameAsync(string name)
        {
            return await dbContext.Set<Type>()
                .AsNoTracking()
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        public async Task<Type?> GetTypeByIdAsync(long id)
        {
            return await dbContext.Set<Type>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsTypeNameExistsAsync(string name)
        {
            return await dbContext.Types.AnyAsync(x => x.Name == name);
        }

        public async Task<Type> AddTypeAsync(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (!string.IsNullOrWhiteSpace(type.Name) && !await IsTypeNameExistsAsync(type.Name))
            {
                dbContext.Types.Add(type);

                await dbContext.SaveChangesAsync();
            }

            return type;
        }

        public async Task<Type> UpdateTypeAsync(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (!string.IsNullOrWhiteSpace(type.Name) && !await IsTypeNameExistsAsync(type.Name))
            {
                dbContext.Types.Attach(type);
                dbContext.Types.Update(type);

                await dbContext.SaveChangesAsync();
            }

            return type;
        }

        public async Task DeleteTypeAsync(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            dbContext.Types.Remove(type);

            await dbContext.SaveChangesAsync();
        }

        public async Task TruncateTable()
        {
            await TruncateTable(TYPES);
        }

    }
}
