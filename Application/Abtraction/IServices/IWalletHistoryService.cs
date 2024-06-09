using Application.Models.WalletHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface IWalletHistoryService
    {
        Task<IEnumerable<WalletHistoryResponse>>GetWalletHistoriesAsync(int walletId);
    }
}
