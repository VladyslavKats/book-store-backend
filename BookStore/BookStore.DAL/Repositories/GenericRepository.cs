using BookStore.DAL.EF;
using BookStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.DAL.Repositories
{
    public class GenericRepository<Tkey, TEntity> : IRepository<Tkey, TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _entities;
        protected readonly BookStoreContext _context;

        public GenericRepository(BookStoreContext context)
        {
            _entities = context.Set<TEntity>();
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _entities.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task DeleteAsync(Tkey id)
        {
            var entity = await _entities.FindAsync(id);
            await DeleteAsync(entity);
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _entities.Attach(entity);
                }
                _entities.Remove(entity);
            });
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string includeProperies = "")
        {
            IQueryable<TEntity> query = _entities;
            if (!string.IsNullOrEmpty(includeProperies))
            {
                foreach (var property in includeProperies
                    .Split(new char[','], StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperies = "")
        {
            IQueryable<TEntity> query = _entities;
            if (!string.IsNullOrEmpty(includeProperies))
            {
                foreach (var property in includeProperies
                    .Split(new char[','], StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<TEntity> GetAsync(Tkey id, string includeProperies = "")
        {
            IQueryable<TEntity> query = _entities;
            if (!string.IsNullOrEmpty(includeProperies))
            {
                foreach (var property in includeProperies
                    .Split(new char[','], StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            query = query.AsNoTracking();
            return await ((DbSet<TEntity>)query).FindAsync(id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                _entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return entity;
            });
        }
    }
}
