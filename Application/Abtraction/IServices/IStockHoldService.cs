using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface IStockHoldService
    {
        Task<IEnumerable<StockHoldRespond>> GetStockHoldsAsync(int userId);
        
    }
}
