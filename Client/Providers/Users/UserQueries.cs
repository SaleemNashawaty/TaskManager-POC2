using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Providers.Users
{
    public static class UserQueries
    {
        public static string UsersListQuery = @"query UserTasks {
                                                      userTasks {
                                                          Id:id
                                                          Name:name
                                                          Email:email
                                                      }
                                                  }";
    }
}
