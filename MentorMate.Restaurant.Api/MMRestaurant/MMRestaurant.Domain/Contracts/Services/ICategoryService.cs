namespace MMRestaurant.Domain.Contracts.Services
{
    using MMRestaurant.Domain.Models.Categories;

    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetCategoriesAsync();

        Task AddCategoryAsync(AddOrEditCategoryModel categoryModel);

        Task EditCategoryAsync(int categoryId, AddOrEditCategoryModel categoryModel);

        Task DeleteCategoryAsync(int categoryId);

        Task<CategoryModel> GetCategoryModelByIdAsync(int categoryId);
    }
}
