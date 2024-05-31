using Application.Models.Wallet;
using Domain.Model;

namespace Application.Abtraction.IServices
{
    public interface IWalletService
    {
        Task UpdateWalletAsync(UpdateWalletRequest request);
        Task<WalletResponse> GetWalletAsync(int UserId);
    }
}
