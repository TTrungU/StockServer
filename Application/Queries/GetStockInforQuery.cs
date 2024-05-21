
using Application.Models.StockInforModel;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetStockInforQuery : IRequest<StockInfor>
    {
        public GetStockInforQuery(string symbol, DateTime? startDay, DateTime? endDay)
        {
            Symbol = symbol;
            StartDay = startDay;
            EndDay = endDay;
        }

        public string Symbol { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
    }
}
