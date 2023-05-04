using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Interfaces;
using NetDDDPokemonApi.Tools;

namespace NetDDDPokemonApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonDbService pokemonDbService;

        public PokemonService(IPokemonDbService pokemonDbService)
        {
            this.pokemonDbService = pokemonDbService;
        }

        public async Task<List<PokemonModel>> GetPokemonListAsync() => (await pokemonDbService.GetPokemonsAsync()).ToPokemonModels();

    }
}
