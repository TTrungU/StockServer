using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotificationNotFoundExceptions: NotFoundException
    {
        public NotificationNotFoundExceptions(int id) : base($"Notification with Id: {id} was not found")
        {
        }
    }
}
