namespace MMRestaurant.Domain.Models.Orders
{
    public class AddOrEditOrderModel
    {
        public string? UserId { get; set; }

        public int TableId { get; set; }

        public List<AddOrEditOrderProduct> Products { get; set; }
    }
}
