using Application.Models.StockInforModel;
using Domain.Entities;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface IStockInforService
    {
        Task<StockInforResponse> GetStockInforAsync(string symbol, DateTime? startDay, DateTime? endDay);
        Task<IEnumerable<HyperLink>> SearchStockInforAsync(string symbol);
        Task<StockInforDailyResponse> GetStockBySearchAsync(int stockInforId);
        Task<IEnumerable<StockInforResponse>> GetAllStockInforAsync();
        Task<StockInforDetailResponse> GetStockInforDetatilAsync(int stockInforId);
    }
}
