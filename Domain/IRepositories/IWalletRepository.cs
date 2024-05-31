using Domain.Entities;
using Domain.Model;
using Domain.Repositories;
using System;

namespace Domain.IRepositories
{
    public interface IWalletRepository :IBaseRepository<Wallet>
    {
       Task<WalletResponse> GetWalletAsync(int userId);
    }
}
