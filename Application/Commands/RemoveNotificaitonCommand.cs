using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class RemoveNotificaitonCommand: IRequest
    {
        public int Id { get;}
        public RemoveNotificaitonCommand(int id)
        {
            Id = id;
        }
    }
}
