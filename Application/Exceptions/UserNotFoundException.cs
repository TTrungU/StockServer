using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int id) : base($"User with Id: {id} was not found")
        {
        }
    }
}
