using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository :IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetByIdAsync(int userId);

        Task<bool> IsEmailExist(string email);
        Task<bool> UserExist(int userId);
       
       
    }
}
