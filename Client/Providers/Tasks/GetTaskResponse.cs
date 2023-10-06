using TaskManager.Client.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Providers.Tasks
{
    public class GetTaskResponse
    {
        public List<TaskData> Tasks { get; set; }
    }
    public class TaskData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DueDate { get; set; }
        public SubData Assignee { get; set; }
        public SubData CreatedUser { get; set; }
        public SubData Status { get; set; }
    }
    public class SubData
    {
        public string Name { get; set; }
    }
}
