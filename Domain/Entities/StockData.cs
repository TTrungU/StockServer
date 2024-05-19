using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockData:BaseEntity
    {
        public DateTime? Date { get; set; }
        public decimal? Close { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public int? Volumne { get; set; }
        public bool? Anomaly { get; set; }
        public string? Signal { get; set; }
        public decimal? LSTMPredict { get; set; }

        public int? StockInforId { get; set; }
        public StockInfor? StockInfor { get; set; }

    }
}
