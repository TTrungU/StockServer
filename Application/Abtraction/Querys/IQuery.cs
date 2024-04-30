using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abtraction.Querys
{

    public interface IQuery
    {
    }

    public interface IQuery<TResult> : IQuery
    {
    }
}
