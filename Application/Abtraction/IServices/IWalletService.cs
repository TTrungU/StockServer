using Application.Models.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface IWalletService
    {
        Task UpdateWallet(UpdateWalletRequest request);
        Task<WalletResponse> GetWalletAsync(int UserId);
    }
}
