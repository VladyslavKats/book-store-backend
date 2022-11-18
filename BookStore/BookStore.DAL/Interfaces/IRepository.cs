using System.Linq.Expressions;

namespace BookStore.DAL.Interfaces
{
    public interface IRepository<TKey,TEntity>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity , bool>> filter , string includeProperies = "");

        Task<TEntity> GetAsync(TKey id , string includeProperies = "");

        Task<IEnumerable<TEntity>> GetAllAsync(string includeProperies = "");

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task DeleteAsync(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
    }
}
