using Application.Models.Transaciton;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface IStockTransacitonService
    {
        Task<IEnumerable<StockTransaction>> GetTransaciton(int userId,string? type);
        Task CreateTransaction(CreateTransactionRequest request);
        Task CancelTransaciton(int transactionId);
        Task RemoveTracsaction(int transactionId);
    }
}
