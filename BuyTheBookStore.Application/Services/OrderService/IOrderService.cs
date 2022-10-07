using BuyTheBookStore.Application.Dtos.OrderAPIDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task<object> CreateOrder(Guid id, OrderDto orderDto);
        Task<object> UpdateOrder (Guid id, OrderDto orderDto);
        Task<object> GetOrders();
        Task<object> GetUserOrders(Guid id);
        Task<object> GetOrder(Guid id);
        Task<object> DeleteOrder(Guid id);

    }
}
