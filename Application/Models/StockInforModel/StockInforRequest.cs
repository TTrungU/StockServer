using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.StockInforModel
{
    public class StockInforRequest
    {
        public string Symbol { get; set; }
        public DateTime? startDay { get; set; }
        public DateTime? endDay { get; set; }
    }
}
