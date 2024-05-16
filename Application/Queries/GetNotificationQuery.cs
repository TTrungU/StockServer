using Application.Models.Notification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetNotificationQuery : IRequest<IEnumerable<NotificationResponse>>
    {
        public int UserId { get; }

        public GetNotificationQuery(int userId)
        {
            UserId = userId;
        }
    }
}
