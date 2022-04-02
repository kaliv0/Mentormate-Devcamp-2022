namespace MMRestaurant.Business.Services
{
    using MMRestaurant.Domain.Constants.Exceptions;
    using MMRestaurant.Domain.Contracts.Repositories;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Entities.Products;
    using MMRestaurant.Domain.Models.Products;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddProductAsync(AddOrEditProductModel productModel)
        {
            //check if category exists
            var category = await _categoryRepository.GetByIdAsync(productModel.ProductCategoryId);
            if (category == null)
            {
                throw new ArgumentException(CategoryErrorMessages.NoCategoryFound);
            }

            //create new product
            var newProduct = new Product
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                ProductCategoryId = productModel.ProductCategoryId
            };

            await _productRepository.AddAsync(newProduct);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task EditProductAsync(int productId, AddOrEditProductModel productModel)
        {
            //check if category exists
            var category = await _categoryRepository.GetByIdAsync(productModel.ProductCategoryId);
            if (category == null)
            {
                throw new ArgumentException(CategoryErrorMessages.NoCategoryFound);
            }

            var productToUpdate = await _productRepository.GetByIdAsync(productId);

            if (productToUpdate == null)
            {
                throw new ArgumentException(ProductErrorMessages.NoProductFound);
            }

            productToUpdate.Name = productModel.Name;
            productToUpdate.Description = productModel.Description;
            productToUpdate.ProductCategoryId = productModel.ProductCategoryId;
            productToUpdate.Price = productModel.Price;

            await _productRepository.EditAsync(productToUpdate);
        }

        public async Task<ResponseProductModel> GetProductsAsync(RequestProductModel requestProductModel)
        {
            var pageStart = requestProductModel.Page != null ? (int)requestProductModel.Page : 1;
            var pageSize = requestProductModel.PageSize != null ? (int)requestProductModel.PageSize : 20;

            var productsInDb = await _productRepository
                .GetProductsAsync(requestProductModel, pageStart, pageSize);

            var products = productsInDb.Item1
                .Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.ProductCategoryId,
                    Category = p.ProductCategory.Name,
                    Description = p.Description,
                    Price = p.Price
                }).ToList();

            var totalCount = productsInDb.Item2;

            //create response model list
            var response = new ResponseProductModel
            {
                Page = pageStart,
                PageSize = pageSize,
                TotalCount = totalCount,
                ProductModels = products
            };

            return response;
        }

        public async Task<ProductModel> GetProductModelByIdAsync(int productId)
        {
            var productInDb = await _productRepository.GetProductByIdAsync(productId);

            var product = new ProductModel
            {
                Id = productInDb.Id,
                Name = productInDb.Name,
                CategoryId = productInDb.ProductCategoryId,
                Category = productInDb.ProductCategory.Name,
                Description = productInDb.Description,
                Price = productInDb.Price
            };

            return product;
        }
    }
}
