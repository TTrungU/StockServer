using Application.Abtraction.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Hanlder
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUserService _userService;

        public RemoveUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(request.Id);
        }
    }
}
