using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Converters;
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
        
        public async Task<List<TypeModel>> GetTypesAsync()
        {
            var types = await dbContext.Set<Type>()
                .AsNoTracking()
                .ToListAsync();

            return types.ToModels();
        }

        public async Task<TypeModel?> GetTypeByNameAsync(string name)
        {
            var type = await dbContext.Set<Type>()
                .AsNoTracking()
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();

            return type.ToModel();
        }

        public async Task<TypeModel?> GetTypeByIdAsync(long id)
        {
            var type = await dbContext.Set<Type>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return type.ToModel();
        }

        public async Task<bool> IsTypeNameExistsAsync(string name)
        {
            return await dbContext.Types.AnyAsync(x => x.Name.Equals(name));
        }

        public async Task<TypeModel?> AddTypeAsync(TypeModel? type)
        {
            var typeDb = type.ToType();
            if (typeDb == null) return null;

            if (!string.IsNullOrWhiteSpace(typeDb.Name) && !await IsTypeNameExistsAsync(typeDb.Name))
            {
                dbContext.Types.Add(typeDb);

                await dbContext.SaveChangesAsync();

                return typeDb.ToModel() ?? type;
            }

            return null;
            
        }

        public async Task<TypeModel?> UpdateTypeAsync(TypeModel? type)
        {
            var typeDb = type.ToType();
            if (typeDb == null) return null;

            if (!string.IsNullOrWhiteSpace(typeDb.Name) && !await IsTypeNameExistsAsync(typeDb.Name))
            {
                dbContext.Types.Attach(typeDb);
                dbContext.Types.Update(typeDb);

                await dbContext.SaveChangesAsync();

                return typeDb.ToModel() ?? type;
            }

            return null;
        }

        public async Task DeleteTypeAsync(TypeModel? type)
        {
            var typeDb = type.ToType();
            if (typeDb == null) return;

            dbContext.Types.Attach(typeDb);
            dbContext.Types.Remove(typeDb);

            await dbContext.SaveChangesAsync();
        }

        public async Task TruncateTableAsync()
        {
            await TruncateTableAsync(TYPES);
        }

    }
}
