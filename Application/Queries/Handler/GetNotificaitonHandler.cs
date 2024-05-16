using Application.Abtraction.IServices;
using Application.Models.Notification;
using MediatR;


namespace Application.Queries.Handler
{
    public class GetNotificaitonHandler : IRequestHandler<GetNotificationQuery, IEnumerable<NotificationResponse>>
    {
        private readonly INotificationService _notificationService;

        public GetNotificaitonHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IEnumerable<NotificationResponse>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            return await _notificationService.GetNotificationsAsync(request.UserId);
        }


    }
}
