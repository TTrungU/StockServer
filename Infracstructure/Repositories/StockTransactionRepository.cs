using Domain.Entities;
using Domain.IRepositories;
using Infracstructure.Datacontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class StockTransactionRepository : BaseRepository<StockTransaction>, IStockTransacitonRespository
    {
        public StockTransactionRepository(DataContext context) : base(context)
        { 
        }

        public async Task<IEnumerable<StockTransaction>> GetTransaction(int userId, string? type)
        {
      
                var query = from transaciton in _context.StockTransactions
                            join stockInfor in _context.StockInfors on transaciton.StockInforId equals stockInfor.Id
                            where transaciton.Id == userId && (type != null ? transaciton.Type == type: true)
                            orderby transaciton.CreateAt descending
                            select new StockTransaction
                            {
                                Id = transaciton.Id,
                                Type = transaciton.Type,
                                Quantity = transaciton.Quantity,
                                TriggerPrice = transaciton.TriggerPrice,
                                DateExpire = transaciton.DateExpire,
                                CreateAt = transaciton.CreateAt,
                                Status = transaciton.Status,
                                StockInfor = stockInfor

                            };
            return await query.ToListAsync();
        }
    }
}
