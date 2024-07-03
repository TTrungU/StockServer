using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StockInforDailyResponse
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public decimal? todayPrice { get; set; }
        public decimal? PercentChange { get; set; }
        public decimal? PriceChange { get; set; }
    }
}
