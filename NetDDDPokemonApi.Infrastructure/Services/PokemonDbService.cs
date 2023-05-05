using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Converters;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Entity.Models;
using NetDDDPokemonApi.Infrastructure.Interfaces;

namespace NetDDDPokemonApi.Infrastructure.Services
{
    public class PokemonDbService : Dbservice, IDbService, IPokemonDbService
    {
        public const string POKEMONS = "Pokemons";
        private readonly ITypeDbService typeDbService;
        public PokemonDbService(PokemonDbContext context, ITypeDbService typeDbService) 
            : base(context) 
        {
            this.typeDbService = typeDbService;
        } 

        public async Task<List<PokemonModel>> GetPokemonsAsync()
        {
            var pokemons = await dbContext.Set<Pokemon>()
                .AsNoTracking()
                .Include(t => t.Types)
                .ToListAsync();
            return pokemons.ToModels();
        }

        public async Task<PokemonModel?> GetPokemonByIdAsync(long id)
        {
            var pokemon = await dbContext.Set<Pokemon>()
                .AsNoTracking()
                .Include(t => t.Types)
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync();

            return pokemon.ToModel();
        }

        public async Task<PokemonModel?> AddPokemon(PokemonModel? pokemon)
        {
            var pokemonDb = await ConvertToPokemon(pokemon);

            if (pokemonDb == null) return null;

            dbContext.Pokemons.Add(pokemonDb);

            await dbContext.SaveChangesAsync();

            return pokemonDb.ToModel();
        }

        public async Task<PokemonModel?> UpdatePokemonAsync(PokemonModel? pokemon)
        {
            var pokemonDb = await ConvertToPokemon(pokemon);

            if (pokemonDb == null) return null;

            dbContext.Pokemons.Attach(pokemonDb);
            dbContext.Pokemons.Update(pokemonDb);

            await dbContext.SaveChangesAsync();

            return pokemonDb.ToModel();
        }

        public async Task DeletePokemonAsync(PokemonModel? pokemon)
        {
            var pokemonDb = await ConvertToPokemon(pokemon);

            if (pokemonDb == null) return;

            dbContext.Pokemons.Remove(pokemonDb);
            await dbContext.SaveChangesAsync();

        }

        public async Task TruncateTableAsync()
        {
            await TruncateTableAsync(POKEMONS);
        }

        private async Task<Pokemon?> ConvertToPokemon(PokemonModel? pokemon)
        {
            if (pokemon == null || pokemon.Types == null || pokemon.Types.Count == 0) return null;

            var types = new List<TypeModel>();

            foreach (var strType in pokemon.Types)
            {
                var type = await typeDbService.GetTypeByNameAsync(strType);
                if (type != null) types.Add(type);
            }

            if (types.Count == 0) return null;

            var pokemonDb = pokemon.ToPokemon(types);

            return pokemonDb;
        }
    }
}
