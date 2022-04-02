namespace MMRestaurant.Data.Configurations.Tables
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MMRestaurant.Domain.Entities.Tables;

    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Tables");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.TableNumber)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.HasAlternateKey(t => t.TableNumber);

            builder.Property(t => t.Capacity)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.HasCheckConstraint("CK_TableCapacity", "[Capacity] >= 2 OR [Capacity] <= 12");
        }
    }
}
