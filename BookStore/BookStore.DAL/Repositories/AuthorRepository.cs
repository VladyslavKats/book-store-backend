using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<string, AuthorEntity>
    {
        public AuthorRepository(BookStoreContext context) : base(context)
        {
        }

        public override Task DeleteAsync(AuthorEntity entity)
        {
            _entities.Attach(entity);
            entity.IsDeleted = true;
            return Task.CompletedTask;
        }

        public override async Task<IEnumerable<AuthorEntity>> GetAllAsync(string includeProperies = "")
        {
            var authors = await base.GetAllAsync(includeProperies);
            return authors.Where(a => !a.IsDeleted);
        }
    }
}
