using Application.Models.User;
using MediatR;

namespace Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public UpdateUserRequest userRequest{get;}

        public UpdateUserCommand(UpdateUserRequest userRequest)
        {
            this.userRequest = userRequest;
        }
    }
}
