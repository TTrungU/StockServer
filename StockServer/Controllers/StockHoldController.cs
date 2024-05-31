using Application.Models.Notification;
using Application.Queries;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockHoldController: ControllerBase
    {
        private readonly IMediator _mediator;

        public StockHoldController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StockHoldRespond>))]
        [Route("UserId")]
        public async Task<IActionResult> GetStockHold(int userId)
        { 
            var query = new GetStockHoldQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
