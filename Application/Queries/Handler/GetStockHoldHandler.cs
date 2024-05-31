using Application.Abtraction.IServices;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handler
{
    public class GetStockHoldHandler : IRequestHandler<GetStockHoldQuery, IEnumerable<StockHoldRespond>>
    {
        private readonly IStockHoldService _stockHoldService;

        public GetStockHoldHandler(IStockHoldService stockHoldService)
        {
            _stockHoldService = stockHoldService;
        }

        public async Task<IEnumerable<StockHoldRespond>> Handle(GetStockHoldQuery request, CancellationToken cancellationToken)
        {
            return await _stockHoldService.GetStockHoldsAsync(request.UserId);
        }
    }
}
