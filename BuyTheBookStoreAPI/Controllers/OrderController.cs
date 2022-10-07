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
            try
            {
                Guid id = Guid.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "jti").Value);
                var order = await _orderService.CreateOrder(id, orderDto);
                if (order == null)
                    return BadRequest("Invalid Order");
                else
                    return Ok(order);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<object> UpdateOrder([FromRoute] Guid id, OrderDto orderDto)
        {

            try
            {
                var order = await _orderService.UpdateOrder(id, orderDto);
                if (order == null)
                    return NotFound($"{id} order not found");
                else
                    return Ok(order);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpGet]
        public async Task<object> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetOrders();
                if (orders == null)
                    return NotFound("No Books In the Store");
                else
                    return orders;
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("userorders/{userId}")]
        public async Task<object> GetUserOrders(Guid userId)
        {
            try
            {
                var orders = await _orderService.GetUserOrders(userId);
                if (orders == null)
                    return NotFound($"{userId} has no order");
                else
                    return Ok(orders);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<object> GetOrder(Guid id)
        {
            try
            {
                var order = await _orderService.GetOrder(id);
                if (order == null)
                    return NotFound($"{id} order does not exist");
                else
                    return Ok(order);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<object> DeleteOrder(Guid id)
        {

            try
            {
                var order = await _orderService.DeleteOrder(id);
                if (order == null)
                    return NotFound($"{id} order does not exist");
                else
                    return Ok(order);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
