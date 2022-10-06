using BuyTheBookStore.Application.Dtos.BookAPIDtos;
using BuyTheBookStore.Application.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyTheBookStoreAPI.Controllers
{
    [Route("books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService; 
        }

        [Authorize]
        [HttpGet]
        public async Task<object> Get()
        {
            return await _bookService.GetAllBooks();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<object> GetBook([FromRoute] Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return NotFound($"{id} book does not exist");
            else
            {
                return Ok(book);  
            }
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<object> CreateBook([FromBody] BookDto bookDto)
        {
            var book = await _bookService.CreateBook(bookDto);
            if (book == null)
                return BadRequest("Something went wrong with the inputs");
            else
                return Ok(book);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<object> UpdateBook([FromRoute]Guid id, [FromBody] BookDto bookDto)
        {
            var book = await _bookService.UpdateBook(id, bookDto);
            if (book == null)
                return NotFound($"{id} book does not exist");
            else
                return Ok(book);
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<object> DeleteBook([FromRoute] Guid id)
        {
            var deletedBook = await _bookService.DeleteBook(id);
            if (deletedBook)
                return Ok($"{id} book successfully deleted");
            else
                return NotFound($"{id} book not found");
        }

    }
}
