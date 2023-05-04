using NetDDDPokemonApi.Infrastructure.Entity.Models;

namespace NetDDDPokemonApi.Infrastructure.Interfaces
{
    public interface IPokemonDbService
    {
        Task<List<Pokemon>> GetPokemonsAsync();
        Task<Pokemon?> GetPokemonByIdAsync(long id);
        Task<Pokemon> UpdatePokemonAsync(Pokemon pokemon);
        Task DeletePokemonAsync(Pokemon pokemon);
    }
}
