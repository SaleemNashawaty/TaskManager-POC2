using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Client.App.Server.Dto
{
    [Bind]
    public class AddTaskDto
    {
        [Required]
        public string Title { get; set; } 

        [StringLength(255)]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        [Required]
        public int CreatedUserId { get; set; }
        public int? AssigneeId { get; set; }
    }
}
