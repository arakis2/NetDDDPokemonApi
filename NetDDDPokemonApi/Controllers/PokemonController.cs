using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetDDDPokemonApi.Queries;

namespace NetDDDPokemonApi.Controllers
{
    // [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        private readonly IMediator mediator;

        public PokemonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/pokemons")]
        public async Task<ActionResult> GetPokemonsAsync()
        {
            var query = new GetPokemonsQuery();
            var pokemons = await mediator.Send(query);

            return Ok(pokemons);
        }
    }
}
