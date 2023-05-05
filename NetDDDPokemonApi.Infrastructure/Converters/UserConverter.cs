using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Entity.Models;


namespace NetDDDPokemonApi.Infrastructure.Converters
{
    public static class UserConverter
    {
        public static User? ToUser(this UserModel? user)
        {
            if (user == null) return null;

            return new User
            {
                Created = user.Created,
                Id = user.Id,
                Password = user.Password,
                Updated = user.Updated,
                UserName = user.UserName
            };
        }

        public static UserModel? ToModel(this User? user)
        {
            if (user == null) return null;

            return new UserModel
            {
                Created = user.Created,
                Id = user.Id,
                Password = user.Password,
                Updated = user.Updated,
                UserName = user.UserName

            };
        }

        public static List<User> ToUsers(this List<UserModel> models)
        {
            var users = new List<User>();

            foreach (var model in models)
            {
                var user = model.ToUser();

                if(user != null) users.Add(user);
            }

            return users;
        }

        public static List<UserModel> ToModels(this List<User> users)
        {
            var models = new List<UserModel>();

            foreach (var user in users)
            {
                var model = user.ToModel();

                if(model != null) models.Add(model);

            }

            return models;
        }
    }
}
