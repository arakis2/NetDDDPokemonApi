using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetDDDPokemonApi.Commands;


namespace NetDDDPokemonApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        private readonly IMediator mediator;
        public InitController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        [HttpGet("/init")]
        public async Task<ActionResult> InitDatabaseAsync()
        {
            var command = new InitDatabaseCommand();

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
