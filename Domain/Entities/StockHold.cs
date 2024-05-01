using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class StockHold:BaseEntity
    {
        public int? UserId { get; set; }
        public int? StockId { get; set; }
        public string? StockSymbol { get; set; }
        public decimal? Price { get; set; }
        public int? Voulume { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public User User { get; set; }



    }
}
