using System.ComponentModel.DataAnnotations;

namespace TaskManager.Server.Core.Entities
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
