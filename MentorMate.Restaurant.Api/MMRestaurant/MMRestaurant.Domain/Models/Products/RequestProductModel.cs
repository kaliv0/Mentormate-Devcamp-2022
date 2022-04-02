namespace MMRestaurant.Domain.Models.Products
{
    public class RequestProductModel
    {
        public string? Product { get; set; }

        public int? CategoryId { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public string? SortBy { get; set; }

        public string? SortDirection { get; set; }
    }
}
