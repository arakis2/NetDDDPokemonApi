using Microsoft.AspNetCore.Mvc;
using NetDDDPokemonApi.Domain.Interfaces;

namespace NetDDDPokemonApi.Controllers
{
    // [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        private readonly IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet("/pokemons")]
        public async Task<ActionResult> GetPokemonsAsync()
        {
            var pokemons = await pokemonService.GetPokemonListAsync();

            return Ok(pokemons);
        }
    }
}
