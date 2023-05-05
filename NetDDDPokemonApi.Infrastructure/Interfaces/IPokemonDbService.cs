using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Entity.Models;

namespace NetDDDPokemonApi.Infrastructure.Interfaces
{
    public interface IPokemonDbService
    {
        Task<List<PokemonModel>> GetPokemonsAsync();
        Task<PokemonModel?> GetPokemonByIdAsync(long id);
        Task<PokemonModel?> AddPokemon(PokemonModel? pokemon);
        Task<PokemonModel?> UpdatePokemonAsync(PokemonModel? pokemon);
        Task DeletePokemonAsync(PokemonModel? pokemon);
        Task TruncateTableAsync();
    }
}
