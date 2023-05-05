using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Interfaces;

namespace NetDDDPokemonApi.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeDbService typeDbService;

        public TypeService(ITypeDbService typeDbService)
        {
            this.typeDbService = typeDbService;
        }

        public async Task<List<TypeModel>> GetTypesAsync() => await typeDbService.GetTypesAsync();

        public async Task<List<TypeModel>> AddTypesAsync(List<TypeModel> models)
        {
            List<TypeModel> types = new List<TypeModel>();
            foreach (var model in models)
            {
                var type = await typeDbService.AddTypeAsync(model);
                if(type != null) types.Add(type);
            }

            return types;
        }
    }
}
