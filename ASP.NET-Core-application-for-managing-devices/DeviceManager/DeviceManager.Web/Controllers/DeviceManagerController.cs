namespace DeviceManager.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DeviceManager.Domain.Models;
    using DeviceManager.Business.Services;
    using DeviceManager.Domain.Exceptions;

    [Route("api/[controller]")]
    [ApiController]
    public class DeviceManagerController : ControllerBase
    {
        private IDeviceManagerService _deviceManagerService;

        public DeviceManagerController(IDeviceManagerService deviceManagerService)
        {
            _deviceManagerService = deviceManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetDeviceModel getDeviceModel)
        {
            try
            {
                var result = await _deviceManagerService.GetAllDevicesAsync(getDeviceModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var device = await _deviceManagerService.GetDeviceByIdAsync(id);
                return Ok(device);
            }
            catch (DeviceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorMessageConstants.ServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateOrUpdateDeviceModel device)
        {

            try
            {
                var result = await _deviceManagerService.AddDeviceAsync(device);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(ErrorMessageConstants.ServerErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CreateOrUpdateDeviceModel device)
        {
            try
            {
                await _deviceManagerService.UpdateDeviceAsync(id, device);
                return Ok();
            }
            catch (DeviceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorMessageConstants.ServerErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _deviceManagerService.DeleteDeviceAsync(id);
                return Ok();
            }
            catch (DeviceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorMessageConstants.ServerErrorMessage);
            }
        }
    }
}
