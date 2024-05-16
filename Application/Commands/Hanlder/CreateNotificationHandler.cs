using Application.Abtraction.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Hanlder
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand>
    {
        private readonly INotificationService _notificationService;

        public CreateNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            await _notificationService.CreateNotificationAsync(request.notificaitonRequest);
        }
    }
}
