using Application.Abtraction.IServices;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handler
{
    public class GetStockInforBySearchHandler : IRequestHandler<GetStockInforBySearchQuery, StockInforDailyResponse>
    {
        private readonly IStockInforService _stockInforService;

        public GetStockInforBySearchHandler(IStockInforService stockInforService)
        {
            _stockInforService = stockInforService;
        }

        public async Task<StockInforDailyResponse> Handle(GetStockInforBySearchQuery request, CancellationToken cancellationToken)
        {
            return await _stockInforService.GetStockBySearchAsync(request.StockInforId);
        }
    }
}
