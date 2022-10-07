using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.DataAccess.Repositories
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<Order> GetOrderByUser(Guid id); 
    }
}
