
using Application.Models.WalletHistory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetWalletHistoryQuery : IRequest<IEnumerable<WalletHistoryResponse>>
    {
        public int WalletId { get;}

        public GetWalletHistoryQuery(int walletId)
        {
            WalletId = walletId;
        }
    }
}
