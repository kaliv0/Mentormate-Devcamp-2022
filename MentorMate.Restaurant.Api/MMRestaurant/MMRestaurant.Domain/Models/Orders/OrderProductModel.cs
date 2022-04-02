namespace MMRestaurant.Domain.Models.Orders
{
    public class OrderProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
