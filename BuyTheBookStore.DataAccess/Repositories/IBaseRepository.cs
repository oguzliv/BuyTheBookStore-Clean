using BuyTheBookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get();
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
