using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetStockInforBySearchQuery : IRequest<StockInforDailyResponse>
    {
        public int StockInforId { get; }

        public GetStockInforBySearchQuery(int stockInforId)
        {
            StockInforId = stockInforId;
        }
    }
}
