using NetDDDPokemonApi.Domain.models;
using Type = NetDDDPokemonApi.Infrastructure.Entity.Models.Type;

namespace NetDDDPokemonApi.Infrastructure.Converters
{
    public static class TypeConverter
    {
        public static List<string> ToListString(this IEnumerable<Type> types)
        {
            var list = new List<string>();
            foreach (var type in types)
            {
                if (!string.IsNullOrWhiteSpace(type.Name))
                {
                    list.Add(type.Name);
                }
            }

            return list;
        }

        public static TypeModel? ToModel(this Type? type)
        {
            if(type == null)
            {
                return null;
            }

            return new TypeModel
            {
                Created = type.Created ?? DateTime.Now,
                Name = type.Name,
                Id = type.Id,
                Updated = type.Updated
            };
        }

        public static List<TypeModel> ToModels(this List<Type> types)
        {
            var models = new List<TypeModel>();

            foreach (var type in types)
            {
                var model = type.ToModel();
                if (model != null)
                {
                    models.Add(model);
                }             
            }

            return models;
        }

        public static Type? ToType(this TypeModel? type)
        {
            if (type == null) 
            {
                return null;
            }

            return new Type
            {
                Created = type.Created,
                Id = type.Id,
                Updated = type.Updated,
                Name = type.Name,
            };
        }

        public static List<Type> ToTypes(this List<TypeModel> types)
        {
            var list = new List<Type>();

            foreach (var type in types)
            {
                var typeDb = type.ToType();

                if(typeDb != null)
                {
                    list.Add(typeDb);
                }
                
            }

            return list;
        }
    }
}
