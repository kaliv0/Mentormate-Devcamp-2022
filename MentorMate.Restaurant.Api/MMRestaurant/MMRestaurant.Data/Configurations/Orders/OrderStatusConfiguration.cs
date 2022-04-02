namespace MMRestaurant.Data.Configurations.Orders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MMRestaurant.Domain.Entities.Orders;

    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");

            builder.HasKey(os => os.Id);

            builder.Property(os => os.Title)
                .HasColumnType("nvarchar")
                .HasMaxLength(20);

            builder.HasMany(os => os.Orders)
                .WithOne(o => o.Status);
        }
    }
}
