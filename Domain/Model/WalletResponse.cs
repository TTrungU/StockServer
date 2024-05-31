using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class WalletResponse
    {
        public int Id { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Total { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Capital { get; set; }
        public string? Status { get; set; }
        public decimal? PercentProfit { get; set; }
        public int UserId { get; set; }
    }
}
