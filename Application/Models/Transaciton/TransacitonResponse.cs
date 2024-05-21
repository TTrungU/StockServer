
using Domain.Entities;

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
