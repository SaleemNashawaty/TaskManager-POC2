using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Core.Models
{
    public class AddTaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedUserId { get; set; }
        public int? AssigneeId { get; set; }
        public int StatusId { get; set; }
    }
}
