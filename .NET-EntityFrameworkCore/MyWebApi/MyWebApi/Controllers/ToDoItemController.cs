namespace MyWebApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyWebApi.Data.Models.Dtos;
    using MyWebApi.Business.Services;
    using MyWebApi.Data.Models.Exceptions;

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private IToDoService _toDoService;

        public ToDoItemController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _toDoService.GetAllItemsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var item = await _toDoService.GetItemByIdAsync(id);
                return Ok(item);
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateOrUpdateToDoItemDTO item)
        {
            try
            {
                var result = await _toDoService.AddItemAsync(item);
                return Ok(result);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CreateOrUpdateToDoItemDTO item)
        {
            try
            {
                await _toDoService.UpdateItemAsync(id, item);
                return Ok();
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _toDoService.DeleteItemAsync(id);
                return Ok();
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server.");
            }
        }
    }
}
