using Application.Abtraction.IServices;
using Domain.IRepositories;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StockHoldService : IStockHoldService
    {
        private readonly IStockHoldRepository _stockHoldRepository;

        public StockHoldService(IStockHoldRepository stockHoldRepository)
        {
            _stockHoldRepository = stockHoldRepository;
        }

        public async Task<IEnumerable<StockHoldRespond>> GetStockHoldsAsync(int userId)
        {
            var stockHolds = await _stockHoldRepository.GetStockHoldsAsync(userId);
            return stockHolds;
        }
    }
}
