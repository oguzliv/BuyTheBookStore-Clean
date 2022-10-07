using BuyTheBookStore.Application.Dtos.OrderAPIDtos;
using BuyTheBookStore.Application.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyTheBookStoreAPI.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderController(IOrderService orderService, IHttpContextAccessor contextAccessor)
        {
            _orderService = orderService;
            _contextAccessor = contextAccessor;
        }

        [Authorize]
        [HttpPost]
        public async Task<object> CreateOrder(OrderDto orderDto)
        {
            Guid id = Guid.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "jti").Value);
            var order = await _orderService.CreateOrder(id,orderDto);
            if (order == null)
                return BadRequest("Invalid Order");
            else
                return Ok(order);
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<object> UpdateOrder([FromRoute] Guid id,OrderUpdateDto orderUpdateDto)
        {

            var order = await _orderService.UpdateOrder(id,orderUpdateDto);
            if (order == null)
                return NotFound($"{id} order not found");
            else
                return Ok(order);

        }
        [Authorize]
        [HttpGet]
        public async Task<object> GetOrders()
        {
            var orders =await _orderService.GetOrders();
            if (orders == null)
                return NotFound("No Books In the Store");
            else
                return orders;
        }
        [Authorize]
        [HttpGet("userorders/{userId}")]
        public async Task<object> GetUserOrders(Guid userId)
        {
            var orders = await _orderService.GetUserOrders(userId);
            if (orders == null)
                return NotFound($"{userId} has no order");
            else
                return Ok(orders);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<object> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);
            if (order == null)
                return NotFound($"{id} order does not exist");
            else
                return Ok(order);

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<object> DeleteOrder(Guid id)
        {

            var order = await _orderService.DeleteOrder(id);
            if (order == null)
                return NotFound($"{id} order does not exist");
            else
                return Ok(order);
        }
    }
}
