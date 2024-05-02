using Application.Abtraction.IServices;
using Application.Models.User;
using MediatR;


namespace Application.Queries.Handler
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IUserService _userService;
        public GetUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
           return await _userService.GetUserByIdsAsync(request.UserId);
        }
    }
}
