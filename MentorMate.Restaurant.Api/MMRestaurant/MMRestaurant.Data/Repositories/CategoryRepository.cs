namespace MMRestaurant.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Entities.Categories;

    public class CategoryRepository : BaseRepository<ProductCategory>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task DeleteRangeAsync(int categoryId)
        {
            var categoryToDelete = await _dbContext.ProductCategories
                .Where(c => c.Id == categoryId)
                    .Include(c => c.Subcategories)
                .Select(c => c)
                .ToListAsync();

            if (!categoryToDelete.Any())
            {
                throw new ArgumentException(CategoryErrorMessages.NoCategoryFound);
            }

            _dbContext.ProductCategories.RemoveRange(categoryToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
