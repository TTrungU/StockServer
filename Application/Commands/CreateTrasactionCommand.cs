using Application.Models.Transaciton;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateTrasactionCommand : IRequest
    {
        public CreateTransactionRequest transactionRequest { get; set; }

        public CreateTrasactionCommand(CreateTransactionRequest request)
        {
            transactionRequest = request;
        }
    }
}
