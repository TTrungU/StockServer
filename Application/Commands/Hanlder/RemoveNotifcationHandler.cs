using Application.Abtraction.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Hanlder
{
    public class RemoveNotifcationHandler : IRequestHandler<RemoveNotificaitonCommand>
    {
        private readonly INotificationService _notificationService;

        public RemoveNotifcationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(RemoveNotificaitonCommand request, CancellationToken cancellationToken)
        {
            await _notificationService.DeleteNotificationAsync(request.Id);
        }
    }
}
