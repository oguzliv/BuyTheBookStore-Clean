using AutoMapper;
using BuyTheBookStore.Application.Dtos.BookAPIDtos;
using BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<object> CreateBook(BookDto book)
        {
            var _book = await _bookRepository.GetBookByAuthorAndName(book.AuthorName, book.Name);

            if (_book != null)
                return null;
            try
            {
                _book = _mapper.Map<Book>(book);
                _book.Id = Guid.NewGuid();
                await _bookRepository.Create(_book);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return _book;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            try
            {
                Book book = await _bookRepository.GetById(id);
                if (book == null)
                    return false;
                await _bookRepository.Delete(book);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<object>> GetAllBooks()
        {
            var list = await _bookRepository.Get();
            return list;
        }

        public async Task<object> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
                return $"{id} book not found";
            else
                return book;
        }

        public async Task<object> UpdateBook(Guid id, BookDto bookDto)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
                return null;

            var newBook = new Book
            {
                Id = id,
                Name = bookDto.Name,
                AuthorName = bookDto.AuthorName,
                SellCount = book.SellCount,
                GenreText = bookDto.GenreText,
                Price = bookDto.Price,
            };
            await _bookRepository.Update(newBook);
            return newBook;
        }
    }
}
