
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
        public async Task<IActionResult> GetStockInforAsync(string Symbol, DateTime? startDay,DateTime? endDay) 
        {
            var query = new GetStockInforQuery(Symbol, startDay, endDay);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
