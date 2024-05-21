using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IStockInforRepository :IBaseRepository<StockInfor>
    {
        Task<StockInfor?> GetSotckData(string symbol, DateTime? dayStart, DateTime? dayEnd); 
    }
}
