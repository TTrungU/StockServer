using Application.Abtraction.IServices;
using Application.Models.Wallet;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IWalletHistoryRepository _historyRepository;
        private readonly INotificationRepository _notificationRepository;

        public WalletService(IWalletRepository walletRepository, IWalletHistoryRepository historyRepository, INotificationRepository notificationRepository)
        {
            _walletRepository = walletRepository;
            _historyRepository = historyRepository;
            _notificationRepository = notificationRepository;
        }

        public Task<WalletResponse> GetWalletAsync(int UserId)
        {

            throw new NotImplementedException();
        }

        public Task UpdateWallet(UpdateWalletRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
