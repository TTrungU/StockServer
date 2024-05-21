using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Wallet :BaseEntity
    {
        public decimal? Deposit { get; set; }
        public string? status { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<WalletHistory>? WalletHistories { get; set; }
    }
}
