using Application.Abtraction.IServices;
using MediatR;


namespace Application.Commands.Hanlder
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.CreateUserAsync(request.UserRequest);
        }
    }
}
