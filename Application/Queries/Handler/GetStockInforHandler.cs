using Application.Abtraction.IServices;
using Domain.Entities;

using MediatR;


namespace Application.Queries.Handler
{
    public class GetStockInforHandler : IRequestHandler<GetStockInforQuery, StockInfor>
    {
        private readonly IStockInforService _stockInforService;

        public GetStockInforHandler(IStockInforService stockInforService)
        {
            _stockInforService = stockInforService;
        }

        public async Task<StockInfor> Handle(GetStockInforQuery request, CancellationToken cancellationToken)
        {
            return await _stockInforService.GetStockInfor(request.Symbol,request.StartDay,request.EndDay);
        }
    }
}
