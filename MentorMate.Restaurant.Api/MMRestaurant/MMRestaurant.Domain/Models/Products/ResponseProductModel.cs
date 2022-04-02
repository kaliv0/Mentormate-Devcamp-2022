namespace MMRestaurant.Domain.Models.Products
{
    public class ResponseProductModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<ProductModel> ProductModels { get; set; }
    }
}
