using Application.Abtraction.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Hanlder
{
    public class CreateTransactionHandler : IRequestHandler<CreateTrasactionCommand>
    {
        private readonly IStockTransacitonService _stockTransacitonService;

        public CreateTransactionHandler(IStockTransacitonService stockTransacitonService)
        {
            _stockTransacitonService = stockTransacitonService;
        }

        public async Task Handle(CreateTrasactionCommand request, CancellationToken cancellationToken)
        {
            await _stockTransacitonService.CreateTransaction(request.transactionRequest);
        }
    }
}
