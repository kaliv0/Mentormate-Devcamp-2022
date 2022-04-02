namespace MMRestaurant.Data.Configurations.Orders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MMRestaurant.Domain.Entities.Orders;

    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts");

            builder.HasKey(op => new
            {
                op.OrderId,
                op.ProductId
            });
        }
    }
}
