using MediatR;
using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;

namespace NetDDDPokemonApi.Queries
{
    public class GetTypesQuery : IRequest<List<TypeModel>>
    {
        public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, List<TypeModel>>
        {
            private readonly ITypeService typeService;

            public GetTypesQueryHandler(ITypeService typeService)
            {
                this.typeService = typeService;
            }

            public async Task<List<TypeModel>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
            {
                return await typeService.GetTypesAsync();
            }
        }
    }
}
