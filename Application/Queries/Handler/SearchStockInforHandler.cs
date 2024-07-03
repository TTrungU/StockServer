using Application.Abtraction.IServices;
using Domain.Model;
using MediatR;


namespace Application.Queries.Handler
{
    public class SearchStockInforHandler : IRequestHandler<SearchStockInforQuery, IEnumerable<HyperLink>>
    {
        private readonly IStockInforService _stockInforService;

        public SearchStockInforHandler(IStockInforService stockInforService)
        {
            _stockInforService = stockInforService;
        }

        public async Task<IEnumerable<HyperLink>> Handle(SearchStockInforQuery request, CancellationToken cancellationToken)
        {
            return await _stockInforService.SearchStockInforAsync(request.Symbol);
        }
    }
}
