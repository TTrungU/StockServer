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

            var sellTransaction = await _context.StockTransactions.Where(t => t.UserId == userId &&
                                                                            t.Type == TransactionType.Buy.ToString() &&
                                                                            t.Status == TransactionStatus.Success.ToString()).ToListAsync();
            var buyTransactions = await  _context.StockTransactions.Where(t => t.UserId == userId &&
                                                                            t.Type == TransactionType.Sell.ToString() &&
                                                                            t.Status == TransactionStatus.Success.ToString()).ToListAsync();

            var latestStocks = await _context.StockDatas
               .GroupBy(s => s.StockInforId)
               .Select(g => g.OrderByDescending(s => s.Date).FirstOrDefault())
               .ToDictionaryAsync(s => s?.StockInforId, s => s?.Close);

            decimal? capital = sellTransaction.Sum(sh => sh.TriggerPrice * sh.Quantity);
            decimal? total = userWallet.Deposit + sellTransaction.Sum(sh => latestStocks.TryGetValue(sh.StockInforId, out var closePrice) ? closePrice * sh.Quantity : 0);

            decimal? profit = buyTransactions.Sum(s => s.Investment);
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
