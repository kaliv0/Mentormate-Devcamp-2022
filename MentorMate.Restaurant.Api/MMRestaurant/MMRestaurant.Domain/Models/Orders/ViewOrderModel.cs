namespace MMRestaurant.Domain.Models.Orders
{
    public class ViewOrderModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderProductModel> OrderProducts { get; set; }

    }
}
