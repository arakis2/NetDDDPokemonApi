using MediatR;
using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Tools;

namespace NetDDDPokemonApi.Commands
{
    public class InitTypesCommand : IRequest<List<TypeModel>>
    {
        public class InitTypesCommandHandler : IRequestHandler<InitTypesCommand, List<TypeModel>>
        {
            private readonly ITypeService typeService;

            public InitTypesCommandHandler(ITypeService typeService)
            {
                this.typeService = typeService;
            }

            public async Task<List<TypeModel>> Handle(InitTypesCommand request, CancellationToken cancellationToken)
            {
                var types = ReadJsonData();

                if(types == null || types.Count == 0)
                {
                    return new List<TypeModel>();
                }

                return await typeService.AddTypesAsync(types);
            }

            private List<TypeModel> ReadJsonData()
            {
                var models = new List<TypeModel>();

                var dataModel = DataReader.ReadDatas();

                if(dataModel?.Types != null && dataModel.Types.Count > 0)
                {
                    models.AddRange(dataModel.Types);
                }

                return models;

            }
        }
    }
}
