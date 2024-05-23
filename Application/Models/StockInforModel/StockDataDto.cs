using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.StockInforModel
{
    public class StockDataDto
    {
        public DateTime? Date { get; set; }
        public decimal? Close { get; set; }    
    }
}
