using Application.Abtraction.IServices;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handler
{
    public class GetNotificationHandler : IRequestHandler<GetWalletQuery, WalletResponse>
    {
        private readonly IWalletService _walletService;

        public GetNotificationHandler(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public async Task<WalletResponse> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            return await _walletService.GetWalletAsync(request.UserId);
        }
    }
}
