using BuyTheBookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.DataAccess.Repositories
{
    public interface IBookRepository:IBaseRepository<Book>
    {
        Task<Book> GetBookByAuthorAndName(string authorName,string bookName);
        Task<IEnumerable<Book>> GetRecommendedBooks(string genre);
    }
}
