using Domain.Entities;
using Domain.Enum;
using Domain.IRepositories;
using Domain.Model;
using Infracstructure.Datacontext;
using Microsoft.EntityFrameworkCore;


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

            var buyTransaction = await _context.StockTransactions.Where(t => t.UserId == userId &&
                                                                            t.Type == TransactionType.Buy.ToString() &&
                                                                            t.Status == TransactionStatus.Success.ToString()).ToListAsync();
            var sellTransactions = await  _context.StockTransactions.Where(t => t.UserId == userId &&
                                                                            t.Type == TransactionType.Sell.ToString() &&
                                                                            t.Status == TransactionStatus.Success.ToString()).ToListAsync();

            var latestStocks = await _context.StockDatas
               .GroupBy(s => s.StockInforId)
               .Select(g => g.OrderByDescending(s => s.Date).FirstOrDefault())
               .ToDictionaryAsync(s => s?.StockInforId, s => s?.Close);

            decimal? capital = userStockHolds.Sum(sh => sh.Voulume * sh.Price);
            decimal? listedSecurities = userStockHolds.Sum(sh => latestStocks.TryGetValue(sh.StockId, out var closePrice) ? closePrice * sh.Voulume : 0);
            decimal? total = userWallet.Deposit + listedSecurities;
            decimal? profit = (listedSecurities - capital);
            decimal? percent = capital != 0 ? (profit / capital) * 100 : 0;

            return new WalletResponse()
            {
                UserId = userId,
                Id = userWallet.Id,
                Total = total,
                ListedSecurities = listedSecurities,
                Capital = capital,
                Profit = profit,
                Balance = userWallet.Deposit,
                PercentProfit = percent
            };
        }
    }
}
