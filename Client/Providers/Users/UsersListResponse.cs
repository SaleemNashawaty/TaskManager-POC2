using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Models;

namespace TaskManager.Client.Providers.Users
{
    public class UsersListResponse
    {
        [JsonProperty("userTasks")]
        public List<UserModel> Users { get; set; }
    }
}
