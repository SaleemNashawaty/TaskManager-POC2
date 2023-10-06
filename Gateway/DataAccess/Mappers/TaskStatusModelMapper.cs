using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskStatus = TaskManager.Core.Entities.TaskStatus;

namespace TaskManager.DataAccess.Mappers
{
    public class TaskStatusModelMapper : IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                    .IsRequired();
         
            // Table & Column Mappings
            builder.ToTable("TaskStatus", "dbo");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
