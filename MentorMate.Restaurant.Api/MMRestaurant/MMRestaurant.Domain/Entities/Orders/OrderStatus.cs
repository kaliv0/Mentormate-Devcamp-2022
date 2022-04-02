namespace MMRestaurant.Domain.Entities.Orders
{
    using MMRestaurant.Domain.Constants.Enums;

    public class OrderStatus
    {
        public int Id { get; set; }

        public OrderStatusCode Title { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
