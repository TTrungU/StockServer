using Application.Commands;
using Application.Models.Wallet;
using Application.Queries;
using Domain.Model;
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
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(WalletResponse))]
        public async Task<IActionResult> GetWallet(int UserId)
        {
            var query = new GetWalletQuery(UserId);
            var result = await _mediator.Send(query);
            return Ok(result);
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
