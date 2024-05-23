using Application.Commands;
using Application.Models.Wallet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWallet(UpdateWalletRequest request)
        {
            var command = new UpdateWalletCommand(request);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
