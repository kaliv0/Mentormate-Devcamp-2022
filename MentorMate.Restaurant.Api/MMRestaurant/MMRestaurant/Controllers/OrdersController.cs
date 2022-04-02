namespace MMRestaurant.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MMRestaurant.Domain.Constants.SuccessMessages;
    using MMRestaurant.Domain.Contracts.Services;
    using MMRestaurant.Domain.Models.Orders;
    using MMRestaurant.Web.Extensions;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] RequestOrderModel requestOrderModel)
        {
            var email = User.GetEmail();
            var role = User.GetRole();

            try
            {
                var orders = await _orderService.GetOrdersAsync(requestOrderModel, email, role);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] AddOrEditOrderModel newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var email = User.GetEmail();

            try
            {
                await _orderService.AddOrderAsync(newOrder, email);
                return Ok(OrderSuccessMessages.SuccessAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderByIdAsync(int orderId)
        {
            var email = User.GetEmail();
            var role = User.GetRole();

            try
            {
                var order = await _orderService.GetOrderModelByIdAsync(orderId, email, role);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> EditOrderAsync(int orderId, [FromBody] AddOrEditOrderModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var email = User.GetEmail();

            try
            {
                await _orderService.EditOrderAsync(orderId, order, email);
                return Ok(OrderSuccessMessages.SuccessEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{orderId}/complete")]
        public async Task<IActionResult> EditOrderCompleteAsync(int orderId)
        {

            try
            {
                await _orderService.EditOrderCompleteAsync(orderId);
                return Ok(OrderSuccessMessages.SuccessEditStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrderAsync(int orderId)
        {
            var email = User.GetEmail();
            var role = User.GetRole();

            try
            {
                await _orderService.DeleteOrderAsync(orderId, email, role);
                return Ok(OrderSuccessMessages.SuccessDelete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
