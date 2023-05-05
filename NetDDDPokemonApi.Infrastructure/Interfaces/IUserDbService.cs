using NetDDDPokemonApi.Domain.models;

namespace NetDDDPokemonApi.Infrastructure.Interfaces
{
    public interface IUserDbService
    {
        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel?> GetUserByIdAsync(long id);
        Task<UserModel?> GetUserByUserNameAsync(string username);
        Task<UserModel?> AddUserAsync(UserModel? user);
        Task<UserModel?> UpdateUserAsync(UserModel? user);
        Task DeleteUserAsync(UserModel? user);
        Task TruncateTableAsync();
    }
}
