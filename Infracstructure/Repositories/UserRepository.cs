using Domain.Entities;
using Domain.Repositories;
using Infracstructure.Datacontext;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext datacontext):base(datacontext){}
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await GetAll().ToListAsync(); 
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId)).FirstOrDefaultAsync();
        }

        public async Task<bool> IsEmailExist(string Email)
        {
       
            return await IsExist(user => user.Email == Email);
        }

        public  async Task<bool> UserExist(int userId)
        {
            return await IsExist(user => user.Id == userId);
        }
    }
}
