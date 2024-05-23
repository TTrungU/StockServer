using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Wallet
{
    public class UpdateWalletRequest
    {
        public int Id { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; }
    }
}
