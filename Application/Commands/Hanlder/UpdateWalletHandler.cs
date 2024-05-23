using Application.Abtraction.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Hanlder
{
    public class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand>
    {
        private readonly IWalletService _walletService;

        public UpdateWalletHandler(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public async Task Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            await _walletService.UpdateWalletAsync(request.updateRequest);
        }
    }
}
