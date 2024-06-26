﻿using Domain.Entities;
using Domain.Model;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IStockHoldRepository: IBaseRepository<StockHold>
    {
        Task<IEnumerable<StockHoldRespond>> GetStockHoldsAsync(int userId);
    }
}
