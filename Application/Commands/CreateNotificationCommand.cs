using Application.Models.Notification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateNotificationCommand : IRequest
    {
        public CreateNotificationRequest notificaitonRequest { get; }

        public CreateNotificationCommand(CreateNotificationRequest request)
        {
            notificaitonRequest = request;
        }
    }
}
