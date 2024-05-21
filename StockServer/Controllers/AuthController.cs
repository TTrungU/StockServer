using Application.Abtraction.IServices;
using Application.Models.Authenticate;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticatedRequest request)
        {
            var query = new AuthenticateQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result); 
        }
    }
}
