using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WalletHistory: BaseEntity
    {
        public decimal? Deposit { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? Status { get; set; }
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }

        public WalletHistory()
        {
            this.CreateAt = DateTime.UtcNow;
        }
    }
}
