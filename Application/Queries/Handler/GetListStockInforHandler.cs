using Application.Abtraction.IServices;
using Application.Models.StockInforModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handler
{
    public class GetListStockInforHandler : IRequestHandler<GetListStockInforQuery, IEnumerable<StockInforResponse>>
    {
        private readonly IStockInforService _stockInforService;

        public GetListStockInforHandler(IStockInforService stockInforService)
        {
            _stockInforService = stockInforService;
        }

        public async Task<IEnumerable<StockInforResponse>> Handle(GetListStockInforQuery request, CancellationToken cancellationToken)
        {
            return await _stockInforService.GetAllStockInforAsync();
        }
    }
}
