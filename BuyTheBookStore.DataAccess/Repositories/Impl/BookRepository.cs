using BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.DataAccess.Repositories.Impl
{
    public class BookRepository : BaseRepository<Book>,IBookRepository
    {
        public BookRepository(ApplicationDbContext db):base(db)
        {

        }

        public async Task<Book> GetBookByAuthorAndName(string authorName, string bookName)
        {
            var book = await DbSet.FirstOrDefaultAsync(b => b.AuthorName == authorName && b.Name == bookName);
            return book;
        }
        public async Task<IEnumerable<Book>> GetRecommendedBooks(string genre)
        {
            if (genre == null)
            {
                return await DbSet.OrderByDescending(b => b.NSPF).Take(5).ToListAsync();
            }
            else if (!System.Enum.IsDefined(typeof(Book.GENRE), genre.ToUpper()))
            {
                return null;
            }
            else
            {
                return await _db.Books.OrderByDescending(b => b.NSPF).Where(b => b.GenreText == genre.ToUpper()).Take(5).ToListAsync();
            }
        }
    }
}
