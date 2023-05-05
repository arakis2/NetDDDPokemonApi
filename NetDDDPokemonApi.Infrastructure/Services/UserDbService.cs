using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Converters;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Entity.Models;
using NetDDDPokemonApi.Infrastructure.Interfaces;


namespace NetDDDPokemonApi.Infrastructure.Services
{
    public class UserDbService : Dbservice, IDbService, IUserDbService
    {
        public const string USERS = "Users";

        public UserDbService(PokemonDbContext context) : base(context) { }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await dbContext.Set<User>()
                .AsNoTracking()
                .ToListAsync();

            return users.ToModels();
        }

        public async Task<UserModel?> GetUserByIdAsync(long id)
        {
            var user = await dbContext.Set<User>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return user.ToModel();
        }

        public async Task<UserModel?> GetUserByUserNameAsync(string username)
        {
            var user = await dbContext.Set<User>()
                .AsNoTracking()
                .Where(x => x.UserName == username)
                .SingleOrDefaultAsync();

            return user.ToModel();
        }

        public async Task<UserModel?> AddUserAsync(UserModel? user)
        {
            var userDb = user.ToUser();

            if(userDb == null) return null;

            dbContext.Users.Add(userDb);

            await dbContext.SaveChangesAsync();

            return userDb.ToModel();
        }

        public async Task<UserModel?> UpdateUserAsync(UserModel? user)
        {
            var userDb = user.ToUser();
            if(userDb == null) return null;

            dbContext.Users.Attach(userDb);
            dbContext.Users.Update(userDb);

            await dbContext.SaveChangesAsync();

            return userDb.ToModel();
        }

        public async Task DeleteUserAsync(UserModel? user)
        {
            var userDb = user.ToUser();
            if (userDb == null) return;

            dbContext.Users.Attach(userDb);
            dbContext.Users.Remove(userDb);

            await dbContext.SaveChangesAsync();
        }

        public async Task TruncateTableAsync()
        {
            await TruncateTableAsync(USERS);
        }
    }
}
