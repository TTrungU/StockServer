using Application.Abtraction.IServices;
using Application.Models.Authenticate;
using MediatR;


namespace Application.Queries.Handler
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateQuery, AuthenticateResponse>
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateHandler(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
            
        public async Task<AuthenticateResponse> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            return await _authenticateService.Authenticated(request.authenticateRequest);
        }
    }
}
