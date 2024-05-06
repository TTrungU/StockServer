using Application.Models.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUserAsync();
        Task<UserResponse> GetUserByIdsAsync(int id);
        Task CreateUserAsync(CreateUserRequest request);
        Task UpdateUserAsync(UpdateUserRequest request);
        Task DeleteUserAsync(int id);
    }
}
