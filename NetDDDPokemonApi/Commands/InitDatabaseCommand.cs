using MediatR;
using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.models;
using NetDDDPokemonApi.Tools;

namespace NetDDDPokemonApi.Commands
{
    public class InitDatabaseCommand : IRequest<DataModel>
    {
        public class InitDatabaseCommandHandler : IRequestHandler<InitDatabaseCommand, DataModel?>
        {
            private readonly ITypeService typeService;
            private readonly IPokemonService pokemonService;
            public InitDatabaseCommandHandler(ITypeService typeService, IPokemonService pokemonService)
            {
                this.typeService = typeService;
                this.pokemonService = pokemonService;
            }

            public async Task<DataModel?> Handle(InitDatabaseCommand request, CancellationToken cancellationToken)
            {
                var dataModel = DataReader.ReadDatas();

                if
                (
                    dataModel == null ||
                    dataModel.Types == null ||
                    !dataModel.Types.Any() ||
                    dataModel.Pokemons == null ||
                    !dataModel.Pokemons.Any() ||
                    dataModel.Users == null ||
                    !dataModel.Users.Any())
                {
                    return null;
                }

                await typeService.TruncateTable();
                await pokemonService.TruncateTable();

                dataModel.Types = await typeService.AddTypesAsync(dataModel.Types);

                

                dataModel.Pokemons = await pokemonService.AddPokemonsAsync(dataModel.Pokemons);


                return dataModel;


            }

            private DataModel? ReadJsonData()
            {

                return DataReader.ReadDatas();

            }
        }
    }
}
