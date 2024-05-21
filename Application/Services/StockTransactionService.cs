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
        private readonly IWalletHistoryRepository _walletHistoryRepository;
        private readonly IStockHoldRepository _stockHoldRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockTransactionService(IMapper mapper, IStockTransacitonRespository stockTransacitonRespository, INotificationRepository notificationRepository, IWalletRepository walletRepository, IUnitOfWork unitOfWork, IStockHoldRepository stockHoldRepository, IWalletHistoryRepository walletHistoryRepository)
        {
            _mapper = mapper;
            _stockTransacitonRespository = stockTransacitonRespository;
            _notificationRepository = notificationRepository;
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
            _stockHoldRepository = stockHoldRepository;
            _walletHistoryRepository = walletHistoryRepository;
        }

        public async Task CancelTransaciton(int transactionId)
        {
            var transaction = await _stockTransacitonRespository.FindByCondition(t => t.Id == transactionId).FirstOrDefaultAsync();
            
            if (transaction == null) 
            {
                throw new NotFoundException("Transaciton not found");
            }

            transaction.Status = TransactionStatus.Cancel.ToString();
            _stockTransacitonRespository.Update(transaction);
            await _stockTransacitonRespository.SaveAsync();
        }

        public async Task CreateTransaction(CreateTransactionRequest request)
        {
            var wallet = await _walletRepository.FindByCondition(w => w.UserId == request.UserId).FirstOrDefaultAsync();
            var stock = await _stockHoldRepository.FindByCondition(s => s.UserId == request.UserId
                                                         && s.StockId == request.StockId
                                                         && s.Status == StockStatus.Holding.ToString()).
                                                         FirstOrDefaultAsync();

            if (wallet == null)     
                throw new NotFoundException("Wallet not found");
            
            if (wallet.Deposit < request.Quantity * request.TriggerPrice && request.Type == TransactionType.Buy.ToString())
                throw new PaymentRequiredException("Not enough money to excute the transaction");

            var total = request.Quantity * request.Price;
            //boy sotck
            if (request.Type == TransactionType.Buy.ToString() && request.Price == request.TriggerPrice )
            {
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
                if (stock == null)
                {
                    var stockHold = new StockHold
                    {
                        Price = request.Price,
                        StockSymbol = request.Symbol,
                        UserId = request.UserId,
                        StockId = request.StockId,
                        Voulume = request.Quantity,
                        Status = StockStatus.Holding.ToString(),
                    };
                    _stockHoldRepository.Create(stockHold);
                } else {
                    stock.Voulume += request.Quantity;
                    _stockHoldRepository.Update(stock);
                }
                
                      
                _notificationRepository.Create(notificaiton);
                _walletHistoryRepository.Create(walletHistory);
                _walletRepository.Update(wallet);
            }
            //Sell stock
            if (request.Type == TransactionType.Sell.ToString() && request.Price == request.TriggerPrice)
            {
                if (stock == null || stock.Voulume < request.Quantity)
                    throw new PaymentRequiredException($"Your {request.Symbol} stock quantity not enough to sell");

                wallet.Deposit += total;
                var walletHistory = new WalletHistory
                {
                    Deposit = wallet.Deposit,
                    WalletId = wallet.Id,
                    Description = $"+ {total}VND |" +
                                                $" Sell stock: {request.Symbol} |" +
                                                $" Balance: {wallet.Deposit} |" +
                                                $" Date: {DateTime.Now} "
                };
                var notificaiton = new Notification
                {
                    UserId = request.UserId,
                    Title = NotificaitonTitle.TransactionSuccess,
                    Description = $"Sell stock {request.Symbol} successed with value: {total}"
                };

                stock.Voulume += request.Quantity;
                _stockHoldRepository.Update(stock);
                _notificationRepository.Create(notificaiton); 
                _walletHistoryRepository.Create(walletHistory);
                _walletRepository.Update(wallet);
            }
            _stockTransacitonRespository.Create(_mapper.Map<StockTransaction>(request));
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<StockTransaction>> GetTransaciton(int userId, string? type)
        {
            var transactions = await _stockTransacitonRespository.GetTransaction(userId, type);
            return transactions;
        }

        public async Task RemoveTracsaction(int transactionId)
        {
            var transaction = await _stockTransacitonRespository.FindByCondition(t => t.Id == transactionId).FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException("Transaciton not found");
            }

            _stockTransacitonRespository.Delete(transaction);
            await _stockTransacitonRespository.SaveAsync();
        }
    }
}
