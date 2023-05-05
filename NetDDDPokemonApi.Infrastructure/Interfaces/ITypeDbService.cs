using NetDDDPokemonApi.Domain.models;


namespace NetDDDPokemonApi.Infrastructure.Interfaces
{
    public interface ITypeDbService
    {
        Task<List<TypeModel>> GetTypesAsync();
        Task<TypeModel?> GetTypeByNameAsync(string name);
        Task<TypeModel?> GetTypeByIdAsync(long id);
        Task<bool> IsTypeNameExistsAsync(string name);
        Task<TypeModel?> AddTypeAsync(TypeModel? type);
        Task<TypeModel?> UpdateTypeAsync(TypeModel? type);
        Task DeleteTypeAsync(TypeModel? type);
        Task TruncateTableAsync();
    }
}
