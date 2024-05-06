using Application.Models.User;
using MediatR;

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
