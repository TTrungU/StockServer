using Application.Abtraction.IServices;
using Application.Models.StockInforModel;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StockInforService : IStockInforService
    {
        private readonly IStockInforRepository _stockInforRepository;

        public StockInforService(IStockInforRepository stockInforRepository)
        {
            _stockInforRepository = stockInforRepository;
        }

        public async Task<StockInfor> GetStockInfor(string symbol, DateTime?startDay, DateTime? endDay)
        {
            var stock = await _stockInforRepository.GetSotckData(symbol, startDay, endDay);
            if (stock == null)
                throw new NotFoundException("Data not found");
            return stock;
        }
    }
}
