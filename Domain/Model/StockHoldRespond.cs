using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StockHoldRespond
    {
        public int? UserId { get; set; }
        public int? StockId { get; set; }
        public string? StockSymbol { get; set; }
        public decimal? Total { get; set; }
        public int? Unit { get; set; }
        public decimal? Percent { get; set; }
    }
}
