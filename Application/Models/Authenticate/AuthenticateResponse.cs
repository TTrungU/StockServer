

using Domain.Entities;

namespace Application.Models.Authenticate
{
    public class AuthenticateResponse
    {
        public AuthenticateResponse(int id, string? token)
        {
            Id = id;
            Token = token;
        }

        public int? Id { get; set; }
        public string? Token { get; set; }
       
    }
}
