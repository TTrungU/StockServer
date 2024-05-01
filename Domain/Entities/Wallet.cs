using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Wallet :BaseEntity
    {
        public int? UserId { get; set; }
        public decimal? deposit { get; set; }
        public string? status { get; set; }
        public User? User { get; set; }
        public ICollection<WalletHistory>? WalletHistories { get; set; }
    }
}
