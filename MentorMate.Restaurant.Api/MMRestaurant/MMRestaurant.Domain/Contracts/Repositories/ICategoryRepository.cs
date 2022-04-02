namespace MMRestaurant.Domain.Contracts.Repositories
{
    using System.Threading.Tasks;
    using MMRestaurant.Domain.Entities.Categories;

    public interface ICategoryRepository : IBaseRepository<ProductCategory>
    {      
        Task DeleteRangeAsync(int categoryId);
    }
}
