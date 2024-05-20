using Domain.Entities;
using Domain.IRepositories;
using Infracstructure.Datacontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class StockHoldRespository : BaseRepository<StockHold>, IStockHoldRepository
    {
        public StockHoldRespository(DataContext context) : base(context)
        {
        }
    }
}
