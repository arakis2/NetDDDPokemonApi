using MediatR;
using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;

namespace NetDDDPokemonApi.Queries
{
    public class GetPokemonsQuery : IRequest<List<PokemonModel>>
    {
        public class GetPokemonsQueryHandler : IRequestHandler<GetPokemonsQuery, List<PokemonModel>>
        {
            private readonly IPokemonService pokemonService;

            public GetPokemonsQueryHandler(IPokemonService pokemonService)
            {
                this.pokemonService = pokemonService;
            }

            public async Task<List<PokemonModel>> Handle(GetPokemonsQuery request, CancellationToken cancellationToken)
            {
                return await pokemonService.GetPokemonListAsync();
            }
        }
    }
}
