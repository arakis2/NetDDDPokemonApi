using Type = NetDDDPokemonApi.Infrastructure.Entity.Models.Type;

namespace NetDDDPokemonApi.Infrastructure.Interfaces
{
    public interface ITypeDbService
    {
        Task<List<Type>> GetTypesAsync();
        Task<List<Type>> GetTypesByNameAsync(string name);
        Task<Type?> GetTypeByIdAsync(long id);
        Task<bool> IsTypeNameExistsAsync(string name);
        Task<Type> AddTypeAsync(Type type);
        Task<Type> UpdateTypeAsync(Type type);
        Task DeleteTypeAsync(Type type);
    }
}
