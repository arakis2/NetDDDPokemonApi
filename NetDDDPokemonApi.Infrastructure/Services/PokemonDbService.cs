using Microsoft.EntityFrameworkCore;
using NetDDDPokemonApi.Domain.models;
using NetDDDPokemonApi.Infrastructure.Converters;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Entity.Models;
using NetDDDPokemonApi.Infrastructure.Interfaces;
using System.Linq;
using System.Text;
using Type = NetDDDPokemonApi.Infrastructure.Entity.Models.Type;

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

        public async Task<PokemonModel?> AddPokemonAsync(PokemonModel? pokemon)
        {
            var pokemonDb = ConvertToPokemon(pokemon);

            if (pokemonDb == null) return null;

          await GetDbTypes(pokemonDb, pokemon?.Types);

            dbContext.Pokemons.Add(pokemonDb);

            await dbContext.SaveChangesAsync();

            return pokemonDb.ToModel();
        }

        public async Task<PokemonModel?> UpdatePokemonAsync(PokemonModel? pokemon)
        {
            var pokemonDb = ConvertToPokemon(pokemon);

            if (pokemonDb == null) return null;

            dbContext.Pokemons.Attach(pokemonDb);
            dbContext.Pokemons.Update(pokemonDb);

            await dbContext.SaveChangesAsync();

            return pokemonDb.ToModel();
        }

        public async Task DeletePokemonAsync(PokemonModel? pokemon)
        {
            var pokemonDb = ConvertToPokemon(pokemon);

            if (pokemonDb == null) return;

            dbContext.Pokemons.Remove(pokemonDb);
            await dbContext.SaveChangesAsync();

        }

        public async Task TruncateTableAsync()
        {
            await TruncateTableAsync(POKEMONS);
        }

        private Pokemon? ConvertToPokemon(PokemonModel? pokemon)
        {
            if (pokemon == null) return null;

            var pokemonDb = pokemon.ToPokemon();       

            return pokemonDb;
        }

        private async Task GetDbTypes(Pokemon pokemon, List<string>? types)
        {
            if (types == null ||!types.Any()) return;
            if(types.Contains("Fée"))
            {
                var test = types;
            }
            foreach (var type in types) 
            {
                if(!await typeDbService.IsTypeNameExistsAsync(type)) continue;
                Type? dbType = await dbContext.Types.FirstOrDefaultAsync(t => t.Name != null && t.Name.Equals(type));
                if (dbType == null) continue;
                dbType.Pokemons = dbType.Pokemons.Add(pokemon);
                pokemon.Types = pokemon.Types.Add(dbType);

            }
        }
    }
}
