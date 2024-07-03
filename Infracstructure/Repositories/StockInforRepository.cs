

using Domain.Entities;
using Domain.IRepositories;
using Domain.Model;
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

        public async Task<StockInforDetailResponse?> GetDetailStockInfor(int stockInforId)
        {
            DateTime? mostRecentDate = await _context.StockDatas.Where(s=>s.StockInforId == stockInforId).MaxAsync(sd => sd.Date);
            int recentYear = mostRecentDate.Value.Year;
            DateTime firstDayRecentYear = new DateTime(recentYear, 1, 2);

            DateTime last30Day = AdjustForWeekend(mostRecentDate.Value.AddDays(-30));

            int lastYear = mostRecentDate.Value.AddYears(-1).Year;
            DateTime firstDayLastYear = new DateTime(lastYear, 1, 3);
            DateTime lastDayLastYear = new DateTime(lastYear, 12, 29);
  
            int last5Year = mostRecentDate.Value.AddYears(-5).Year;
            DateTime firstDayLast5Year = new DateTime(last5Year, 1,2 );
            //DateTime lastDayLast5Year = new DateTime(last5Year, 12, 28);

                                    
            var rawData = await (from stockInfor in _context.StockInfors
                                 join stockData in _context.StockDatas on stockInfor.Id equals stockData.StockInforId
                                 where stockData.Date >= firstDayLast5Year && stockInfor.Id == stockInforId
                                 orderby stockData.Date descending
                                 select new
                                 {
                                     stockData.Date,
                                     stockData.Close
                                 }).ToListAsync();
            var symbol = await _context.StockInfors.Where(s=> s.Id == stockInforId).Select(s=>s.Symbol).FirstOrDefaultAsync();
            var LastDayPrice = rawData.Where(s => s.Date ==mostRecentDate).Select(s => s.Close).FirstOrDefault();
            var Last30DayPrice = rawData.Where(s => s.Date == last30Day).Select(s => s.Close).FirstOrDefault();
            var YearToDatePrice = rawData.Where(s => s.Date == firstDayRecentYear).Select(s => s.Close).FirstOrDefault();
            var Last1YearFirstDatePrice = rawData.Where(s => s.Date == firstDayLastYear).Select(s => s.Close).FirstOrDefault();
            var Last1YearLastDatePrice = rawData.Where(s => s.Date == lastDayLastYear).Select(s => s.Close).FirstOrDefault();
            var Last5YearFirstDatePrice = rawData.Where(s => s.Date == firstDayLast5Year).Select(s => s.Close).FirstOrDefault();
            //var Last5YearLastDatePrice = rawData.Where(s => s.Date == lastDayLast5Year).Select(s => s.Close).FirstOrDefault();

            return new StockInforDetailResponse()
            {
                Id = stockInforId,
                Symbol = symbol,
                LastDate = mostRecentDate,
                LastDayPrice = LastDayPrice,
                ProfitPercent30Days = (LastDayPrice - Last30DayPrice) / Last30DayPrice * 100,
                ProfitPercentYearToDate = (LastDayPrice - YearToDatePrice) / YearToDatePrice * 100,
                ProfitPercentLastYear = (Last1YearLastDatePrice - Last1YearFirstDatePrice) / Last1YearFirstDatePrice * 100,
                ProfitPercent5YearsAgo = (Last1YearLastDatePrice - Last5YearFirstDatePrice) / Last5YearFirstDatePrice * 100

            };
   
        }

        private DateTime AdjustForWeekend(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.AddDays(2); // Nếu là thứ Bảy, tăng thêm 2 ngày
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(1); // Nếu là Chủ Nhật, tăng thêm 1 ngày
            }
            return date; // Nếu không phải cuối tuần, trả về ngày ban đầu
        }

        public async Task<IEnumerable<StockInfor>?> GetListStockInfor()
        {
            DateTime? mostRecentDate = await _context.StockDatas.MaxAsync(sd => sd.Date);         
            DateTime startDay = mostRecentDate.Value.AddDays(-365);


            var query = from stockInfor in _context.StockInfors
                        join stockData in _context.StockDatas on stockInfor.Id equals stockData.StockInforId
                        where stockData.Date >= startDay
                        group stockData by new {stockInfor.Id, stockInfor.Symbol } into g
                        select new StockInfor
                        {
                            Id = g.Key.Id,
                            Symbol = g.Key.Symbol,
                            StockDatas = g.Select(s => new StockData
                            {
                                Date = s.Date,
                                Close = s.Close,
                            }).OrderBy(s => s.Date).ToList()
                        };
            return await query.ToListAsync();
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
                            }).OrderBy(s=>s.Date).ToList()
                        };
            return await query.FirstOrDefaultAsync();
        }

        public async Task<StockInforDailyResponse?> GetStocInforBySearch(int stockInforId)
        {
            DateTime? today = await _context.StockDatas.Where(s => s.StockInforId == stockInforId).MaxAsync(sd => sd.Date);
            DateTime lastDay = MinnWeekend(today.Value.AddDays(-1));
            var todayPrice = await _context.StockDatas.Where(s => s.StockInforId == stockInforId && s.Date == today).Select(s=>s.Close).FirstOrDefaultAsync();
            var lastDayPrice = await _context.StockDatas.Where(s => s.StockInforId == stockInforId && s.Date == lastDay).Select(s => s.Close).FirstOrDefaultAsync();
            var symbol = await _context.StockInfors.Where(s => s.Id == stockInforId).Select(s => s.Symbol).FirstOrDefaultAsync();
            var priceChange = todayPrice - lastDayPrice;
            var percent = priceChange / todayPrice * 100;        
            var roundedPernent = Math.Ceiling(percent.GetValueOrDefault() * 100) / 100;

            return new StockInforDailyResponse()
            {
                Id = stockInforId,
                Symbol = symbol,
                todayPrice = todayPrice,
                PercentChange = roundedPernent,
                PriceChange = priceChange

            };
        }

        private DateTime MinnWeekend(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.AddDays(-1); // Nếu là thứ Bảy, trừ thêm 1 ngày
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(-2); // Nếu là Chủ Nhật, tăng trừ thêm 2 ngày
            }
            return date; // Nếu không phải cuối tuần, trả về ngày ban đầu
        }

        public async Task<IEnumerable<HyperLink>> SearchStockInfor(string Symbol)
        {
            var stock = await _context.StockInfors.Where(s => s.Symbol.ToLower().Contains(Symbol.Trim().ToLower()))
                                                  .Select(s=> new HyperLink {Id = s.Id, Name = s.Symbol })
                                                  .OrderBy(s=>s.Name)
                                                  .ToListAsync();

            return stock;
        }
    }
}
