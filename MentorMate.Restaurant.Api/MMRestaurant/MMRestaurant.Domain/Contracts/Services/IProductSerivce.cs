namespace MMRestaurant.Domain.Contracts.Services
{
    using MMRestaurant.Domain.Models.Products;

    public interface IProductService
    {
        Task<ResponseProductModel> GetProductsAsync(RequestProductModel requestProductModel);

        Task AddProductAsync(AddOrEditProductModel productModel);

        Task EditProductAsync(int productId, AddOrEditProductModel productModel);

        Task DeleteProductAsync(int productId);

        Task<ProductModel> GetProductModelByIdAsync(int productId);
    }
}
