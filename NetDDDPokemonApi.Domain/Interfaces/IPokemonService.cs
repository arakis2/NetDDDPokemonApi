using NetDDDPokemonApi.Domain.models;

namespace NetDDDPokemonApi.Domain.Interfaces
{
    public interface IPokemonService
    {
        Task<List<PokemonModel>> GetPokemonListAsync();
        Task TruncateTable();
        Task<List<PokemonModel>> AddPokemonsAsync(List<PokemonModel> models);
    }
}
