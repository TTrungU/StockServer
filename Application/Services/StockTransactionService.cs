using Application.Abtraction.IServices;
using Application.Models.Transaciton;
using AutoMapper;
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
    public class StockTransactionService : IStockTransacitonService
    {
        private readonly IMapper _mapper;
        private readonly IStockTransacitonRespository _stockTransacitonRespository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IStockInforRepository _stockInforRepository;
        private readonly IWalletHistoryRepository _walletHistoryRepository;
        private readonly IStock
        private readonly IUnitOfWork _unitOfWork;

        public StockTransactionService(IMapper mapper, IStockTransacitonRespository stockTransacitonRespository, INotificationRepository notificationRepository, IWalletRepository walletRepository, IStockInforRepository stockInforRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _stockTransacitonRespository = stockTransacitonRespository;
            _notificationRepository = notificationRepository;
            _walletRepository = walletRepository;
            _stockInforRepository = stockInforRepository;
            _unitOfWork = unitOfWork;
        }

        public Task CancelTransaciton(int transactionId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTransaction(CreateTransactionRequest request)
        {
            var wallet = await _walletRepository.FindByCondition(w => w.UserId == request.UserId).FirstOrDefaultAsync();      
           
            if (wallet == null)     
                throw new NotFoundException("Wallet not found");
            
            if (wallet.Deposit < request.Quantity * request.TriggerPrice)
                throw new PaymentRequiredException("Not enough money to excute the transaction");
            
            if (request.Type == TransactionType.Buy.ToString() && request.Price <= request.TriggerPrice )
            { 
                var total = request.Quantity * request.Price;
                wallet.Deposit -= total;
                var walletHistory = new WalletHistory
                {
                    Deposit = wallet.Deposit,
                    WalletId = wallet.Id,
                    Description = $"- {total}VND |" +
                                                $" Buy stock: {request.Symbol} |" +
                                                $" Balance: {wallet.Deposit} |" +
                                                $" Date: {DateTime.Now} "
                };
                var notificaiton = new Notification
                {
                    UserId = request.UserId,
                    Title = NotificaitonTitle.TransactionSuccess,
                    Description = $"Buy stock {request.Symbol} successed with value: {total}"
                };
                var stockHold = new StockHold
                {
                    Price = request.Price,
                    StockSymbol = request.Symbol,
                    UserId = request.UserId,
                    StockId = request.StockId,
                    Voulume = request.Quantity,
                    Status = StockStatus.Holding.ToString(),

                };
                _sto
                _notificationRepository.Create(notificaiton);
                _walletHistoryRepository.Create(walletHistory);
                _walletRepository.Update(wallet);
            }
        }

        public Task RemoveTracsaction(int transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
