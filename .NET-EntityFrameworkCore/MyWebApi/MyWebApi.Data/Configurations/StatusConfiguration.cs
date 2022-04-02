namespace MyWebApi.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyWebApi.Data.Models.Entities;

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("StatusCodes");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Title)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);

            builder.HasMany(s => s.ToDoItems)
                .WithOne(t => t.Status);
        }
    }
}
