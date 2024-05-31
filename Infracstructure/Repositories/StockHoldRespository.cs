using Domain.Entities;
using Domain.IRepositories;
using Domain.Model;
using Infracstructure.Datacontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class StockHoldRespository : BaseRepository<StockHold>, IStockHoldRepository
    {
        public StockHoldRespository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StockHoldRespond>> GetStockHoldsAsync(int userId)
        { 
            var userStockHolds = await _context.StockHolds
                                .Where(sh => sh.UserId == userId && sh.Status == "Holding")
                                .ToListAsync();

            var latestStocks = await _context.StockDatas
                               .GroupBy(s => s.StockInforId)
                               .Select(g => g.OrderByDescending(s => s.Date).FirstOrDefault())
                               .ToDictionaryAsync(s => s?.StockInforId, s => s?.Close);

            var stockSummaries = userStockHolds
                              .GroupBy(sh => new { sh.StockSymbol, sh.StockId })
                              .Select(g => {
   
                                  var totalVolume = g.Sum(sh => sh.Voulume);
                                  var totalPrice = g.Sum(sh => sh.Voulume * (latestStocks.TryGetValue(sh.StockId, out var closePrice) ? closePrice : 0));
                                  var totalCost = g.Sum(sh => sh.Voulume * sh.Price);
                                  var percentProfit = totalCost != 0 ? ((totalPrice - totalCost) / totalCost) * 100 : 0;

                                  return new StockHoldRespond
                                  {
                                      UserId = userId,
                                      StockId = g.Key.StockId,
                                      StockSymbol = g.Key.StockSymbol,
                                      Total = totalPrice,
                                      Unit = totalVolume,
                                      Percent = percentProfit,
                                  
                                  };
                              })
                              .ToList();
            return stockSummaries;
        }
    }
}
