namespace MyWebApi.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyWebApi.Data.Models.Entities;

    internal class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.ToTable("ToDoItems");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            builder.HasOne(t => t.Priority)
                .WithMany(p => p.ToDoItems)
                .HasForeignKey(t => t.PriorityId);

            builder.HasOne(t => t.Status)
                .WithMany(s => s.ToDoItems)
                .HasForeignKey(t => t.StatusId);
        }
    }
}
