using Application.Commands;
using Application.Models.Transaciton;
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

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
        { 
            var command = new CreateTrasactionCommand(request);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
