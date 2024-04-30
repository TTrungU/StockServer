using Application.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public int UserId { get; }
        public GetUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
