namespace MMRestaurant.Domain.Models.Orders
{
    public class RequestOrderModel
    {
        public string? WaiterName { get; set; }

        public int? TableNumber { get; set; }

        public string? Status { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public string? SortBy { get; set; }

        public string? SortDirection { get; set; }
    }
}
