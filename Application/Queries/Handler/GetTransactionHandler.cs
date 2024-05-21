

using Application.Abtraction.IServices;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Handler
{
    public class GetTransactionHandler : IRequestHandler<GetTransactionQuery, IEnumerable<StockTransaction>>
    {
        private readonly IStockTransacitonService _stockTransacitonService;

        public GetTransactionHandler(IStockTransacitonService stockTransacitonService)
        {
            _stockTransacitonService = stockTransacitonService;
        }

        public async Task<IEnumerable<StockTransaction>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _stockTransacitonService.GetTransaciton(request.UserId, request?.Type);
        }
    }
}
