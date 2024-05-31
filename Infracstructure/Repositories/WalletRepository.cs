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
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DataContext context) : base(context)
        {
        }


        public async Task<WalletResponse> GetWalletAsync(int userId)
        {
            var userWallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
                if (userWallet == null) return null;
            var userStockHolds = await _context.StockHolds.Where(sh => sh.UserId == userId && sh.Status =="Holding").ToListAsync();

            var latestStocks = await _context.StockDatas
               .GroupBy(s => s.StockInforId)
               .Select(g => g.OrderByDescending(s => s.Date).FirstOrDefault())
               .ToDictionaryAsync(s => s?.StockInforId, s => s?.Close);

            decimal? capital = userStockHolds.Sum(sh => sh.Price * sh.Voulume);
            decimal? total = userWallet.Deposit + userStockHolds.Sum(sh => latestStocks.TryGetValue(sh.StockId, out var closePrice) ? closePrice * sh.Voulume : 0);

            decimal? profit = total - capital - userWallet.Deposit;
            decimal? percent = capital != 0 ? (profit / capital) * 100 : 0;

            return new WalletResponse()
            {
                UserId = userId,
                Id = userWallet.Id,
                Total = total,
                Capital = capital,
                Profit = profit,
                Balance = userWallet.Deposit,
                PercentProfit = percent
            };
        }
    }
}
