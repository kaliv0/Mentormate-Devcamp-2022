namespace MMRestaurant.Domain.Models.Orders
{
    public class ResponseOrderModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<OrderModel> OrderModels { get; set; }
    }
}
