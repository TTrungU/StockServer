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
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DataContext context) : base(context)
        {
        }


        async Task<object> IWalletRepository.GetWalletAsync(int userId)
        {

            DateTime today = DateTime.Today;
            var query = from user in _context.Users
                        join wallet in _context.Wallets on user.Id equals wallet.Id
                        join stockHold in _context.StockHolds on user.Id equals stockHold.UserId
                        join stockInfor in _context.StockInfors on stockHold.StockId equals stockInfor.Id
                        join stockData in _context.StockDatas on stockInfor.Id equals stockData.StockInforId
                        where stockHold.Status == "Holding" && user.Id == userId && stockData.Date == today 
                        group new { wallet, stockHold, stockData } by new { wallet.Id, wallet.deposit } into g
  
                        let total = g.Key.deposit + g.Sum(x => x.stockData.Close * x.stockHold.Voulume)
                        let capital = g.Sum(x => x.stockHold.Price * x.stockHold.Voulume)
                        let profit = total - capital - g.Key.deposit
                        let percent = capital != 0 ? (profit / capital) * 100 : 0
                        select new
                        {
                            WalletId = g.Key.Id,
                            Deposit = g.Key.deposit,
                            Total = total,
                            Capital = capital,
                            Profit = profit,
                            PercentProfit = percent

                        };
            return await query.FirstOrDefaultAsync();
        }
    }
}
