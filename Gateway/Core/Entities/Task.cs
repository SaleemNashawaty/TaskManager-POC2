using System.ComponentModel.DataAnnotations;

namespace TaskManager.Server.Core.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedUserId { get; set; }
        public int? AssigneeId { get; set; }
        public int StatusId { get; set; }
        public User Assignee { get; set; }
        public User CreatedUser { get; set; }
        public TaskStatus Status { get; set; }
    }
}
