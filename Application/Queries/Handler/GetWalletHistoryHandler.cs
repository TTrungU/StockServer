using Application.Abtraction.IServices;
using Application.Models.WalletHistory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handler
{
    public class GetWalletHistoryHandler : IRequestHandler<GetWalletHistoryQuery, IEnumerable<WalletHistoryResponse>>
    {
        private readonly IWalletHistoryService _walletHistoryService;

        public GetWalletHistoryHandler(IWalletHistoryService walletHistoryService)
        {
            _walletHistoryService = walletHistoryService;
        }

        public async Task<IEnumerable<WalletHistoryResponse>> Handle(GetWalletHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _walletHistoryService.GetWalletHistoriesAsync(request.WalletId);
        }
    }
}
