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
        Task<StockInfor> GetStockInfor(string symbol, DateTime? startDay, DateTime? endDay);
    }
}
