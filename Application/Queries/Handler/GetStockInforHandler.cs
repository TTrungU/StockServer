using Application.Abtraction.IServices;
using Application.Models.StockInforModel;
using Domain.Entities;

using MediatR;


namespace Application.Queries.Handler
{
    public class GetStockInforHandler : IRequestHandler<GetStockInforQuery, StockInforResponse>
    {
        private readonly IStockInforService _stockInforService;

        public GetStockInforHandler(IStockInforService stockInforService)
        {
            _stockInforService = stockInforService;
        }

        public async Task<StockInforResponse> Handle(GetStockInforQuery request, CancellationToken cancellationToken)
        {
            return await _stockInforService.GetStockInforAsync(request.Symbol,request.StartDay,request.EndDay);
        }
    }
}
