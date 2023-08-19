using Microsoft.EntityFrameworkCore;
using OnlineStoreApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OnlineStoreDBContext _context;
        public readonly DbSet<T> _entities;
        public Repository(OnlineStoreDBContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();  
        }
    }

    /*
     Scenarios in which you would typically call `_context.SaveChangesAsync()`:

    1. After Adding Entities:
        When you have added new entities to the context using `Add` or `AddRange`, you would call `SaveChangesAsync` to insert those entities into the database.

    2. After Modifying Entities:
   When you have modified properties of existing entities using Entity Framework's change tracking mechanism, you would call `SaveChangesAsync` to update those changes in the database.

    3. After Deleting Entities:
   When you have marked entities for deletion using `Remove`, you would call `SaveChangesAsync` to delete those entities from the database.

    4. After Batch Operations:
   If you have performed a batch of operations involving adding, updating, and deleting entities, you would call `SaveChangesAsync` at the end to persist all the changes together.

     */
}
