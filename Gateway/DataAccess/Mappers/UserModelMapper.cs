using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;

namespace TaskManager.DataAccess.Mappers
{
    public class UserModelMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                    .IsRequired();

            // Table & Column Mappings
            builder.ToTable("User", "dbo");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Email).HasColumnName("Email");
        }
    }
}
