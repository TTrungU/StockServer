using Domain.IRepositories;
using Infracstructure.Datacontext;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Rollback()
        {
            throw new NotImplementedException();
        }

        
    }
}
