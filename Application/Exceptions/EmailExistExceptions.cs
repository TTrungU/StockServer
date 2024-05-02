using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EmailExistExceptions : ConflictException
    {
        public EmailExistExceptions(string Email) : base($"Email: {Email} was already exist")
        {

        }
    }
}
