using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<string, AuthorEntity>
    {
        public AuthorRepository(BookStoreContext context) : base(context)
        {
        }

        public override async Task DeleteAsync(AuthorEntity entity)
        {
            await Task.Run(() =>
            {
                _entities.Attach(entity);
                entity.IsDeleted = true;
            });
        }
    }
}
