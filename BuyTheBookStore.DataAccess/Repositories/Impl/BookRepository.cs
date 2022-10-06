using BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Persistence;
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
    }
}
