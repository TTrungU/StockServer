using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetWalletQuery: IRequest<WalletResponse>
    {
        public int UserId { get; }

        public GetWalletQuery(int userId)
        {
            UserId = userId;
        }
    }
}
