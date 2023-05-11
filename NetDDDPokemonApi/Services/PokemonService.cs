using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Interfaces;

namespace NetDDDPokemonApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonDbService pokemonDbService;

        public PokemonService(IPokemonDbService pokemonDbService)
        {
            this.pokemonDbService = pokemonDbService;
        }

        public async Task<List<PokemonModel>> GetPokemonListAsync() => await pokemonDbService.GetPokemonsAsync();

        public async Task TruncateTable()
        {
            await pokemonDbService.TruncateTableAsync();
        }

        public async Task<List<PokemonModel>> AddPokemonsAsync(List<PokemonModel> models)
        {
            var results = new List<PokemonModel>();

            foreach (var model in models)
            {
                var pokemon = await pokemonDbService.AddPokemonAsync(model);

                if(pokemon != null)
                {
                    results.Add(pokemon);
                }
            }

            return results;
        }

    }
}
