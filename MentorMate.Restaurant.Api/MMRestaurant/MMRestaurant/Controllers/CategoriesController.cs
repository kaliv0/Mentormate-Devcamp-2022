namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MMRestaurant.Domain.Constants;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Models.Categories;

    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddOrEditCategoryModel newCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _categoryService.AddCategoryAsync(newCategory);
                return Ok(CategorySuccessMessages.SuccessAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryModelByIdAsync(categoryId);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> EditCategoryAsync(int categoryId, [FromBody] AddOrEditCategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _categoryService.EditCategoryAsync(categoryId, category);
                return Ok(CategorySuccessMessages.SuccessEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(categoryId);
                return Ok(CategorySuccessMessages.SuccessDelete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
