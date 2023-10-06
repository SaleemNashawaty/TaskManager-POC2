using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Models;

namespace TaskManager.Client.Core.Queries
{
    public class ListUserQuery:IRequest<IList<UserModel>>
    {
    }
}
