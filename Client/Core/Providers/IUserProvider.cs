using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Models;

namespace TaskManager.Client.Core.Providers
{
    public interface IUserProvider
    {
        Task<IList<UserModel>> ListUserAsync();
    }
}
