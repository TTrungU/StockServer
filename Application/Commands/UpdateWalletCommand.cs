using Application.Models.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateWalletCommand : IRequest
    {
        public UpdateWalletRequest updateRequest { get; }

        public UpdateWalletCommand(UpdateWalletRequest updateRequest)
        {
            this.updateRequest = updateRequest;
        }
    }
}
