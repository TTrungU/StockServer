using Application.Models.Notification;
using Application.Models.StockInforModel;
using Application.Queries;
using Application.Queries.Handler;
using Domain.Model;
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


        [HttpGet("stockInforId")]
        [ProducesResponseType(200, Type = typeof(StockInforDetailResponse))]
        public async Task<IActionResult> GetStockInforDetail(int stockinforId)
        {
            var query = new GetStockInforDetailQuery(stockinforId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("Search/symbol")]
        [ProducesResponseType(200, Type = typeof(HyperLink))]
        public async Task<IActionResult> SearchStockInfor(string symbol)
        {
            var query = new SearchStockInforQuery(symbol);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("Daily/stockInforId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HyperLink>))]
        public async Task<IActionResult> GetStockInforSummary(int stockinforId)
        {
            var query = new GetStockInforBySearchQuery(stockinforId);
            var result = await _mediator.Send(query);
            return Ok(result);
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
