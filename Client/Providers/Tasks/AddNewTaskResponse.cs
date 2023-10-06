using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Providers.Tasks
{
    public class AddNewTaskResponse
    {
        [JsonProperty("addTask")]
        public Task Response { get; set; }
    }
    public class Task
    {
        public int Id { get; set; }
    }
}
