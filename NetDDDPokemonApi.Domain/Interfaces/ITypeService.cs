using NetDDDPokemonApi.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDDDPokemonApi.Domain.Interfaces
{
    public interface ITypeService
    {
        Task<List<TypeModel>> GetTypesAsync();
        Task<List<TypeModel>> AddTypesAsync(List<TypeModel> models);
        Task TruncateTable();
    }
}
