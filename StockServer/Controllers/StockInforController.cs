using Application.Models.Notification;
using Application.Models.StockInforModel;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockInforController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockInforController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(StockInforResponse))]
        public async Task<IActionResult> GetStockInfor(string Symbol, DateTime? startDay,DateTime? endDay) 
        {
            var query = new GetStockInforQuery(Symbol, startDay, endDay);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StockInforResponse>))]
        public async Task<IActionResult> GetListStocks()
        { 
            var query = new GetListStockInforQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
