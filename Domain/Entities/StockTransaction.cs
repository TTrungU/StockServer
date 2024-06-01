using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockTransaction:BaseEntity
    {
        public string? StockId { get; set; }
        public string? Type { get; set; }
        public int? Quantity { get; set; }
        public decimal? TriggerPrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? Investment { get; set; }
        public DateTime? DateExpire { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateAt { get; set; } 
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public int? StockInforId { get; set; }
        public StockInfor? StockInfor { get; set; }
        public User? User { get; set; }

    }
}
