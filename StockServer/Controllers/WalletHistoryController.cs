using Application.Models.WalletHistory;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletHistoryController: ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WalletHistoryResponse>))]
        [Route("WalletId")]
        public async Task<IActionResult> GetWalletHistory(int walletId)
        {
            var query = new GetWalletHistoryQuery(walletId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
