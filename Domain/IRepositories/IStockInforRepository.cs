using Domain.Entities;
using Domain.Model;
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
        Task<IEnumerable<HyperLink>> SearchStockInfor(string Symbol);
        Task<StockInforDailyResponse?> GetStocInforBySearch(int stockInforId);
        Task<IEnumerable<StockInfor>?> GetListStockInfor();
        Task<StockInforDetailResponse?> GetDetailStockInfor(int stockInforId);
    }
}
