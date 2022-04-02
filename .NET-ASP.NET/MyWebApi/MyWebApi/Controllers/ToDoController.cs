namespace MyWebApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyWebApi.Data.Models.Dtos;
    using MyWebApi.Data.Models.Exceptions;
    using MyWebApi.Business.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItemDTO>> Get()
        {
            try
            {
                return Ok(_toDoService.GetAllItems().ToList());
            }
            catch (ItemListNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItemDTO> Get(Guid id)
        {
            try
            {
                var item = _toDoService.GetItemById(id);
                return Ok(item);
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateOrUpdateToDoItemDTO item)
        {
            try
            {
                return Ok(_toDoService.AddItem(item));
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] CreateOrUpdateToDoItemDTO item)
        {
            try
            {
                _toDoService.UpdateItem(id, item);
                return Ok();
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("An error occured on the server");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _toDoService.DeleteItem(id);
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
