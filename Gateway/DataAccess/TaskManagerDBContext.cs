using Microsoft.EntityFrameworkCore;
using TaskManager.Server.Core.Entities;
using Task = TaskManager.Server.Core.Entities.Task;

namespace TaskManager.Server.DataAccess
{
    public class TaskManagerDBContext: DbContext
    {
        public TaskManagerDBContext(DbContextOptions<TaskManagerDBContext> options):base(options)
        {

        }
        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Core.Entities.TaskStatus> TaskStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedTasks)
                .WithOne(u => u.Assignee!)
                .HasForeignKey(u => u.AssigneeId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedTasks)
                .WithOne(u => u.CreatedUser!)
                .HasForeignKey(u => u.CreatedUserId);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Assignee)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(u => u.AssigneeId);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.CreatedUser)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(u => u.CreatedUserId);
        }
    }
}
