namespace MMRestaurant.Domain.Entities.Orders
{
    using MMRestaurant.Domain.Entities.Tables;

    public class Order
    {
        public int Id { get; set; }

        public int TableId { get; set; }

        public virtual Table Table { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
