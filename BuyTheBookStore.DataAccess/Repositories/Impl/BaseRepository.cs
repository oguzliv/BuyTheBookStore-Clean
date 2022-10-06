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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            DbSet = db.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            _db.SaveChanges();
            return addedEntity;
        }

        public async Task<T> Delete(T entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await _db.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await DbSet.SingleOrDefaultAsync(s => s.Id == id); ;
        }

        public async Task<T> Update(T entity)
        
        {
            _db.ChangeTracker.Clear();
            DbSet.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
