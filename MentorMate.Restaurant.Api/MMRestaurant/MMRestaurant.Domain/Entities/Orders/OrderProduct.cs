namespace MMRestaurant.Domain.Entities.Orders
{
    using MMRestaurant.Domain.Entities.Products;

    public class OrderProduct
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductCount { get; set; }
    }
}
