namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MMRestaurant.Domain.Contracts.Services;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTablesAsync()
        {
            try
            {
                var tables = await _tableService.GetTablesAsync();
                return Ok(tables);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{tableId}")]
        public async Task<IActionResult> GetTableByIdAsync(int tableId)
        {
            try
            {
                var table = await _tableService.GetTableModelByIdAsync(tableId);

                return Ok(table);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
