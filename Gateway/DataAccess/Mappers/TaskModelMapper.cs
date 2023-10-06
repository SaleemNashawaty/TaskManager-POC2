using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using Task = TaskManager.Core.Entities.Task;
namespace TaskManager.DataAccess.Mappers
{
    public class TaskModelMapper : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
            builder.Property(t => t.Title)
                    .IsRequired();
            builder.Property(t => t.DateCreated)
                    .IsRequired();
            builder.Property(t => t.CreatedBy)
                    .IsRequired();
            builder.Property(t => t.StatusId)
                    .IsRequired();
            // Table & Column Mappings
            builder.ToTable("Task", "dbo");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Title).HasColumnName("Title");
            builder.Property(t => t.Description).HasColumnName("Description");
            builder.Property(t => t.DueDate).HasColumnName("DueDate");
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated");
            builder.Property(t => t.StatusId).HasColumnName("StatusId");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
        }
    }
}
