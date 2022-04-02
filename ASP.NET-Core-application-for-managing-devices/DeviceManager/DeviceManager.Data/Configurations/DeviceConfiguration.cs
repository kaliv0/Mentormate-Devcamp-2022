using DeviceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceManager.Data.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Model)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

             builder.Property(t => t.Manufacturer)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();
            

            builder.Property(t => t.ReleaseDate)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(t => t.DateTaken)
              .HasColumnType("date");
        }
    }
}
