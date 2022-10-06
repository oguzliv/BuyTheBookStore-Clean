using BuyTheBookStore.Application.Dtos.BookAPIDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.BookService
{
    public interface IBookService
    {
        Task<object> CreateBook(BookDto book);
        Task<object> UpdateBook(Guid id ,BookDto bookUpdateDto);
        Task<bool> DeleteBook(Guid id);
        Task<object> GetBookById(Guid id);
        Task<IEnumerable<object>> GetAllBooks();
    }
}
