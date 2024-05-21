using Application.Commands;
using Application.Models.Transaciton;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockTransactionController: ControllerBase
    {
        private readonly IMediator _mediator;

        public StockTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransaction(int userId, string? type)
        {
            var query = new GetTransactionQuery(userId, type);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
        { 
            var command = new CreateTrasactionCommand(request);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
