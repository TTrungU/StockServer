using Application.Models.Authenticate;


namespace Application.Abtraction.IServices
{
    public interface IAuthenticateService
    {
        Task<AuthenticateResponse> Authenticated(AuthenticatedRequest loginRequest);
    }
}
