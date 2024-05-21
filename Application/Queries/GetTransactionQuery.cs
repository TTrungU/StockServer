using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetTransactionQuery: IRequest<IEnumerable<StockTransaction>>
    {
        public GetTransactionQuery(int userId, string? type)
        {
            UserId = userId;
            Type = type;
        }

        public int UserId { get;}
        public string? Type { get; }
    }
}
