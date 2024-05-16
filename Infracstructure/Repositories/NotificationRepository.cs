using Domain.Entities;
using Domain.IRepositories;
using Domain.Repositories;
using Infracstructure.Datacontext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(int id)
        {
            Expression<Func<Notification, bool>> expression = notification => notification.UserId == id;

            return await FindByCondition(expression).OrderBy(n => n.CreateAt).ToListAsync();
        }
    }
}
