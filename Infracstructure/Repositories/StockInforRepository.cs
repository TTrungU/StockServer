

using Domain.Entities;
using Domain.IRepositories;
using Domain.Repositories;
using Infracstructure.Datacontext;
using Microsoft.EntityFrameworkCore;

namespace Infracstructure.Repositories
{
    public class StockInforRepository : BaseRepository<StockInfor>, IStockInforRepository
    {
        public StockInforRepository(DataContext context) : base(context)
        {
        }

        public async Task<StockInfor?> GetSotckData(string symbol, DateTime? dayStart, DateTime? dayEnd)
        {
            var query = from stockInfor in _context.StockInfors
                        join stockData in _context.StockDatas on stockInfor.Id equals stockData.StockInforId
                        where stockInfor.Symbol == symbol 
                            && (!dayStart.HasValue || stockData.Date >= dayStart)
                            && (!dayEnd.HasValue || stockData.Date  <= dayEnd)
                        group stockData by new {stockInfor.Id,stockInfor.Symbol } into g
                        select new StockInfor
                        {
                            Id = g.Key.Id,
                            Symbol = g.Key.Symbol,
                            StockDatas = g.Select( s => new StockData 
                            {
                                Date = s.Date,
                                Close = s.Close,
                            }).ToList()
                        };
            return await query.FirstOrDefaultAsync();
        }
    }
}
