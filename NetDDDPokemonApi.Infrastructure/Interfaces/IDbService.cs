
namespace NetDDDPokemonApi.Infrastructure.Interfaces
{
    public interface IDbService
    {
        Task TruncateTableAsync();
    }
}
