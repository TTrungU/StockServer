using Domain.Entities;
using Domain.IRepositories;
using Domain.Repositories;
using Infracstructure.Datacontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class WalletHistoryRepository : BaseRepository<WalletHistory>, IWalletHistoryRepository
    {
        public WalletHistoryRepository(DataContext context) : base(context)
        {
        }
    }
}
