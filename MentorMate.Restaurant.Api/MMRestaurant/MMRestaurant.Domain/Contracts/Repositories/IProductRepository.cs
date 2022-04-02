namespace MMRestaurant.Domain.Contracts.Repositories
{
    using MMRestaurant.Domain.Entities.Products;
    using MMRestaurant.Domain.Models.Products;

    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<(List<Product>, int)> GetProductsAsync(
            RequestProductModel requestProductModel, int pageStart, int pageSize);

        Task<Product> GetProductByIdAsync(int productId);
    }
}
