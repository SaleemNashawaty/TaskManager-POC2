using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.Core.Commands
{
    public class CreateNewTaskCommand: IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedUserId { get; set; }
        public int? AssigneeId { get; set; }
        public CreateNewTaskCommand(string title, string description, DateTime? dueDate, int createdUserId, int? assigneeId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreatedUserId = createdUserId;
            AssigneeId = assigneeId;
        }
    }
}
