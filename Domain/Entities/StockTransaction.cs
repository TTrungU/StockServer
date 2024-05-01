using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockTransaction:BaseEntity
    {
        public string? StockId { get; set; }
        public string? Symbol { get; set; }
        public string? Type { get; set; }
        public decimal? TriggerPrice { get; set; }
        public DateTime? CreateAt { get; set; } 
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
