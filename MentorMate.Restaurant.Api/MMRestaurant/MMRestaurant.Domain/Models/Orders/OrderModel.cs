namespace MMRestaurant.Domain.Models.Orders
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int TableId { get; set; }

        public int TableNumber { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
