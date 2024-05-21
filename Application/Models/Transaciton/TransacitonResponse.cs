using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Transaciton
{
    public class TransacitonResponse
    {
        public string? StockId { get; set; }
        public string? Type { get; set; }
        public int? Quantity { get; set; }
        public decimal? TriggerPrice { get; set; }
        public DateTime? DateExpire { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public int? StockInforId { get; set; }
        public StockInfor? StockInfor { get; set; }

    }
}
