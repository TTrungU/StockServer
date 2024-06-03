using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StockInforDetailResponse
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public DateTime? LastDate { get; set; }     
        public decimal? LastDayPrice { get; set; }
        public decimal? ProfitPercentYearToDate { get; set;}
        public decimal? ProfitPercentLastYear { get; set; }
        public decimal? ProfitPercent30Days { get; set; }
        public decimal? ProfitPercent5YearsAgo { get; set; }


    }
}
