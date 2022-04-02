namespace MMRestaurant.Business.Services
{
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Entities.Categories;
    using MMRestaurant.Domain.Models.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(AddOrEditCategoryModel categoryModel)
        {
            if (categoryModel.ParentCategoryId != null)
            {
                var parent = await _categoryRepository.GetByIdAsync((int)categoryModel.ParentCategoryId);
                if (parent == null)
                {
                    throw new ArgumentException(CategoryErrorMessages.NoCategoryFound);
                }
            }

            var newCategory = new ProductCategory
            {
                Name = categoryModel.Name,
                ParentCategoryId = categoryModel.ParentCategoryId,
            };

            await _categoryRepository.AddAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _categoryRepository.DeleteRangeAsync(categoryId);
        }

        public async Task EditCategoryAsync(int categoryId, AddOrEditCategoryModel categoryModel)
        {
            if (categoryModel.ParentCategoryId != null)
            {
                await _categoryRepository.GetByIdAsync((int)categoryModel.ParentCategoryId);
            }

            var categoryToEdit = await _categoryRepository.GetByIdAsync(categoryId);

            if (categoryToEdit == null)
            {
                throw new ArgumentException(CategoryErrorMessages.NoCategoryFound);
            }


            categoryToEdit.Name = categoryModel.Name;
            categoryToEdit.ParentCategoryId = categoryModel.ParentCategoryId;

            await _categoryRepository.EditAsync(categoryToEdit);
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var result = categories
               .Select(c => new CategoryModel
               {
                   Id = c.Id,
                   Name = c.Name,
                   Subcategories = categories.Where(sc => sc.ParentCategoryId == c.Id)
                                      .Select(sc => new CategoryModel
                                      {
                                          Id = sc.Id,
                                          Name = sc.Name
                                      })
                                      .OrderBy(sc => sc.Name)
                                  .ToList()
               })
               .OrderBy(c => c.Name)
               .ToList();

            return result;
        }

        public async Task<CategoryModel> GetCategoryModelByIdAsync(int categoryId)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var result = categories
                .Where(c => c.Id == categoryId)
               .Select(c => new CategoryModel
               {
                   Id = c.Id,
                   Name = c.Name,
                   Subcategories = categories.Where(sc => sc.ParentCategoryId == c.Id)
                                      .Select(sc => new CategoryModel
                                      {
                                          Id = sc.Id,
                                          Name = sc.Name
                                      })
                                      .OrderBy(sc => sc.Name)
                                  .ToList()
               })
               .OrderBy(c => c.Name)
               .ToList();

            if (!result.Any())
            {
                return null;
            }

            return result[0];
        }
    }
}
