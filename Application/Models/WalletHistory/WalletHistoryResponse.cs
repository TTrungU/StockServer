using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.WalletHistory
{
    public class WalletHistoryResponse
    {
        public int Id { get; set; }
        public decimal? Deposit { get; set; }
        public string? Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateAt { get; set; }
        public string? Status { get; set; }
    }
}
