using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetStockHoldQuery: IRequest<IEnumerable<StockHoldRespond>>
    {
        public int UserId { get; }

        public GetStockHoldQuery(int userId)
        {
            UserId = userId;
        }
    }
}
