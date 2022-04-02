namespace MyWebApi.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyWebApi.Data.Models.Entities;

    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.ToTable("Priorities");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);

            builder.HasMany(p => p.ToDoItems)
               .WithOne(t => t.Priority);
        }
    }
}
