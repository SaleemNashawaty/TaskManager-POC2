using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager.Client.Worker
{
    public class OnTaskAddedResponse
    {
        [JsonProperty("onTaskAdded")]
        public int Id{ get; set; }
    }
    public class TaskModel
    {
        public int Id { get; set; }
    }
}
