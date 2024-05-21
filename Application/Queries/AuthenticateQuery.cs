using Application.Models.Authenticate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class AuthenticateQuery :IRequest<AuthenticateResponse>
    {
        public AuthenticatedRequest authenticateRequest { get; set; }

        public AuthenticateQuery(AuthenticatedRequest authenticate)
        {
            authenticateRequest = authenticate;
        }
    }
}
