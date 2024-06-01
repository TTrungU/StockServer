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
          

            if (wallet == null)     
                throw new NotFoundException("Wallet not found");
            
            if (wallet.Deposit < request.Quantity * request.TriggerPrice && request.Type == TransactionType.Buy.ToString())
                throw new PaymentRequiredException("Not enough money to excute the transaction");

            var transaciton = _mapper.Map<StockTransaction>(request);

            var total = request.Quantity * request.Price;
            //buy sotck
            if (request.Type == TransactionType.Buy.ToString() && request.Price == request.TriggerPrice )
            {
                transaciton.Status = TransactionStatus.Success.ToString();
                wallet.Deposit -= total;
                var walletHistory = new WalletHistory
                {
                    Deposit = wallet.Deposit,
                    WalletId = wallet.Id,
                    CreateAt = DateTime.Now,
                    Description = $"- {total}VND |" +
                                                $" Buy stock: {request.Symbol} |" +
                                                $" Balance: {wallet.Deposit} |" +
                                                $" Date: {DateTime.Now} "
                };
                var notificaiton = new Notification
                {
                    UserId = request.UserId,
                    Title = NotificaitonTitle.TransactionSuccess,
                    Description = $"Buy stock {request.Symbol} successed with value: {total}",
                    CreateAt = DateTime.Now
                };
                
               
                var stockHold = new StockHold
                {
                    Price = request.Price,
                    StockSymbol = request.Symbol,
                    UserId = request.UserId,
                    StockId = request.StockId,
                    Voulume = request.Quantity,
                    Status = StockStatus.Holding.ToString(),
                    CreateAt = DateTime.Now
                };
                 
                
                _stockHoldRepository.Create(stockHold);                                                  
                _notificationRepository.Create(notificaiton);
                _walletHistoryRepository.Create(walletHistory);
                _walletRepository.Update(wallet);
            }
            //Sell stock
            if (request.Type == TransactionType.Sell.ToString() && request.Price == request.TriggerPrice)
            {
                var stockHolds = await _stockHoldRepository.FindByCondition(s => s.UserId == request.UserId
                                                       && s.StockId == request.StockInforId
                                                       && s.Status == StockStatus.Holding.ToString())
                                                       .OrderBy(s => s.CreateAt)
                                                       .ToListAsync();

                if (stockHolds == null || stockHolds.Sum(s => s.Voulume) < request.Quantity)
                    throw new PaymentRequiredException($"Your {request.Symbol} stock quantity not enough to sell");

                wallet.Deposit += total;
                var walletHistory = new WalletHistory
                {
                    Deposit = wallet.Deposit,
                    WalletId = wallet.Id,
                    Description = $"+ {total}VND |" +
                                                $" Sell stock: {request.Symbol} |" +
                                                $" Balance: {wallet.Deposit} VND |" +
                                                $" Date: {DateTime.Now} "
                };
                var notificaiton = new Notification
                {
                    UserId = request.UserId,
                    Title = NotificaitonTitle.TransactionSuccess,
                    Description = $"Sell stock {request.Symbol} successed with value: {total}"
                };
                var unit = request.Quantity;
                transaciton.Investment = 0;
                foreach (var s in stockHolds)
                {
                    if (s.Voulume > unit)
                    {
                        transaciton.Investment += request.TriggerPrice * request.Quantity - s.Price * unit;
                        s.Voulume -= unit;
                        _stockHoldRepository.Update(s);
                        break;

                    }

                    if (s.Voulume == unit)
                    {
                        transaciton.Investment += request.TriggerPrice * request.Quantity - s.Price * unit;
                        s.Voulume -= unit;
                        s.Status = StockStatus.Selled.ToString();
                        _stockHoldRepository.Update(s);
                        break;
                    }

                    if (s.Voulume < unit)
                    {
                        s.Voulume = 0;
                        unit -= s.Voulume;
                        transaciton.Investment += request.TriggerPrice * request.Quantity - s.Price * unit;
                        s.Status = s.Status = StockStatus.Selled.ToString();
                        _stockHoldRepository.Update(s);
                    }                      
                }
                transaciton.Status = TransactionStatus.Success.ToString();
                _notificationRepository.Create(notificaiton); 
                _walletHistoryRepository.Create(walletHistory);
                _walletRepository.Update(wallet);

            }            
            _stockTransacitonRespository.Create(transaciton);
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
