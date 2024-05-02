using Application.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserRequest UserRequest { get; }

        public CreateUserCommand(CreateUserRequest userRequest)
        {
            UserRequest = userRequest;
        }
    }
}
