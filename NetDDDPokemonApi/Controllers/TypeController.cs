using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetDDDPokemonApi.Commands;
using NetDDDPokemonApi.Queries;

namespace NetDDDPokemonApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public TypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/types")]
        public async Task<IActionResult> GetTypesAsync() 
        {
            var query = new GetTypesQuery();

            var results = await mediator.Send(query);

            return Ok(results);
        }

    }
}
