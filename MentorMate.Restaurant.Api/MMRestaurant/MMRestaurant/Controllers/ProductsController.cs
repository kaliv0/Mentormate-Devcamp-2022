namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MMRestaurant.Domain.Constants;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Models.Products;

    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] RequestProductModel requestProductModel)
        {
            try
            {
                var products = await _productService.GetProductsAsync(requestProductModel);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] AddOrEditProductModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _productService.AddProductAsync(newProduct);
                return Ok(ProductSuccessMessages.SuccessAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            try
            {
                var product = await _productService.GetProductModelByIdAsync(productId);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> EditProductAsync(int productId, [FromBody] AddOrEditProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _productService.EditProductAsync(productId, product);
                return Ok(ProductSuccessMessages.SuccessEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            try
            {
                await _productService.DeleteProductAsync(productId);
                return Ok(ProductSuccessMessages.SuccessDelete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
