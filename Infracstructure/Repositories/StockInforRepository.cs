

using Domain.Entities;
using Domain.IRepositories;
using Domain.Repositories;
using Infracstructure.Datacontext;

namespace Infracstructure.Repositories
{
    public class StockInforRepository : BaseRepository<StockInfor>, IStockInforRepository
    {
        public StockInforRepository(DataContext context) : base(context)
        {
        }
    }
}
