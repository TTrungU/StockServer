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
    public class GetStockInforDetailHandler : IRequestHandler<GetStockInforDetailQuery, StockInforDetailResponse>
    {
        private readonly IStockInforService _stockInforService;

        public GetStockInforDetailHandler(IStockInforService stockInforService)
        {
            _stockInforService = stockInforService;
        }

        public async Task<StockInforDetailResponse> Handle(GetStockInforDetailQuery request, CancellationToken cancellationToken)
        {
            return await _stockInforService.GetStockInforDetatilAsync(request.StockInforId);
        }
    }
}
