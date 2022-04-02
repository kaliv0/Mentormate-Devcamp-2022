namespace MMRestaurant.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MMRestaurant.Domain.Entities.Products;
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Models.Products;
    using MMRestaurant.Domain.Contracts.Repositories;

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<(List<Product>, int)> GetProductsAsync(
            RequestProductModel requestProductModel, int pageStart, int pageSize)
        {
            var products = _dbContext.Products
                .Include(p => p.ProductCategory)                
                .AsQueryable();

            if (!products.Any())
            {
                throw new ArgumentException(ProductErrorMessages.NoProductsFound);
            }

            //filtering products
            if (requestProductModel.CategoryId != null)
            {
                products = products.Where(p => p.ProductCategoryId == (int)requestProductModel.CategoryId);
            }

            if (requestProductModel.Product != null)
            {
                products = products.Where(p => p.Name == (string)requestProductModel.Product);
            }

            //sorting products
            if (requestProductModel.SortBy != null)
            {
                if (requestProductModel.SortDirection == "desc")
                {
                    if (requestProductModel.SortBy == "Name")
                    {
                        products = products.OrderByDescending(p => p.Name);
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.ProductCategory.Name);
                    }
                }
                else
                {
                    if (requestProductModel.SortBy == "Name")
                    {
                        products = products.OrderBy(p => p.Name);
                    }
                    else
                    {
                        products = products.OrderBy(p => p.ProductCategory.Name);
                    }
                }
            }

            var totalCount = await products.CountAsync();
            products = products.Skip(pageSize * (pageStart - 1)).Take(pageSize);
            return (await products.ToListAsync(), totalCount);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var products = await _dbContext.Products
               .Where(p => p.Id == productId)
               .Include(p => p.ProductCategory)
               .ToListAsync();

            if (!products.Any())
            {
                throw new ArgumentException(ProductErrorMessages.NoProductFound);
            }

            return products[0];
        }
    }
}
