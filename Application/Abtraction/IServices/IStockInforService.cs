using Application.Models.StockInforModel;
using Domain.Entities;
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
        Task<IEnumerable<StockInforResponse>> GetAllStockInforAsync();
    }
}
