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
    public class UserRepository :BaseRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext db):base(db)
        {
        }

        //public async Task<User> Create(User entity)
        //{
        //    var user = await _db.Users.AddAsync(entity);
        //    _db.SaveChanges();
        //    return user.Entity;
        //}

        //public async Task<User> GetById(Guid id)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        //    return user;
        //}

        //public async Task<IEnumerable<User>> Get()
        //{
        //    var users = await _db.Users.ToListAsync();
        //    return users;
        //}

        //public async Task<User> Update(User entity)
        //{
        //    _db.ChangeTracker.Clear();
        //    var user = _db.Users.Update(entity);
        //    _db.SaveChanges();
        //    return user.Entity;
        //}
        public async Task<User> GetByEmail(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        //public async Task<User> Delete(User user)
        //{
        //    var removedUser =  _db.Users.Remove(user).Entity;
        //    await _db.SaveChangesAsync();
        //    return removedUser;
        //}
    }
}
