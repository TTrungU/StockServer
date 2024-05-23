using Application.Abtraction.IServices;
using Application.Exceptions;
using Application.Models.Wallet;
using Domain.Constants;
using Domain.Entities;
using Domain.Enum;
using Domain.Exceptions;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUnitOfWork _unitOfWork;

        public WalletService(IWalletRepository walletRepository, IWalletHistoryRepository historyRepository, INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _walletRepository = walletRepository;
            _historyRepository = historyRepository;
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<WalletResponse> GetWalletAsync(int UserId)
        {

            throw new NotImplementedException();
        }

        public async Task UpdateWalletAsync(UpdateWalletRequest request)
        {
            var wallet = await  _walletRepository.FindByCondition(u => u.Id == request.Id).FirstOrDefaultAsync();

            if (wallet == null) 
            {
                throw new NotFoundException("Wallet not found");
            }


            if (request.Status == WalletStatus.Deposit.ToString())
            {
                var walletHistory = new WalletHistory()
                {
                    WalletId = request.Id,
                    Description = $"{WalletDescription.TopUp} +{request.Deposit} VND" +
                                  $"Balance: {wallet.Deposit} " +
                                  $"Date: {DateTime.Now}",
                    Deposit = wallet.Deposit,
                    Status = WalletStatus.Deposit.ToString(),                 
                };

                wallet.Deposit += request.Deposit;

                var notification = new Notification()
                {
                    UserId = wallet.UserId,
                    Title = NotificaitonTitle.TopUpSuccess,
                    Description = $"Top-Up {request.Deposit} VND to wallet success"

                };

                _notificationRepository.Create(notification);
                _historyRepository.Create(walletHistory);
                _walletRepository.Update(wallet);
                
            }

            if (request.Status == WalletStatus.Withdraw.ToString())
            {
                if(wallet.Deposit < request.Deposit)
                    throw new PaymentRequiredException("Wallet not enough money to withdraw");

                var walletHistory = new WalletHistory()
                {
                    WalletId = request.Id,
                    Description = $"{WalletDescription.WithDraw} -{request.Deposit} VND " +
                                 $"Balance: {wallet.Deposit} " +
                                 $"Date: {DateTime.Now}",
                    Deposit = wallet.Deposit,
                    Status = WalletStatus.Deposit.ToString(),
                };

                var notification = new Notification()
                {
                    UserId = wallet.UserId,
                    Title = NotificaitonTitle.TopUpSuccess,
                    Description = $"Withdrew {request.Deposit} VND to wallet success"

                };

                wallet.Deposit-= request.Deposit;
                _historyRepository.Create(walletHistory);
                _walletRepository.Update(wallet);
                _notificationRepository.Create(notification);
            }

            await _unitOfWork.Commit();

            
        }
    }
}
