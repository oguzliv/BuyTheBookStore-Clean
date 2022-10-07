using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.DataAccess.Repositories.Impl
{
    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db):base(db)
        {

        }

        public async Task<Order> GetOrderByUser(Guid id)
        {
            return await DbSet.SingleOrDefaultAsync(o => o.UserId == id);
        }
    }
}
