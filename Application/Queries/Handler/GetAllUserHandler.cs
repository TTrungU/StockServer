
using Application.Abtraction.IServices;
using Application.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handler
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserResponse>>
    {
        private readonly IUserService _userService;
        public GetAllUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUserAsync();
        }
    }
}
