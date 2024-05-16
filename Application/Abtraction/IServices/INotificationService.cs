using Application.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.IServices
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationResponse>> GetNotificationsAsync(int userId);
        Task CreateNotificationAsync(CreateNotificationRequest request);
        Task DeleteNotificationAsync(int id);
    }
}
