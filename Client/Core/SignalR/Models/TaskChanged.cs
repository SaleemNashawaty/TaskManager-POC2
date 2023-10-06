using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Core.SignalR.Models
{
    public class TaskChanged
    {
        public int Id { get; set; }
        public TaskChanged(int id)
        {
            Id = id;
        }
    }
}
