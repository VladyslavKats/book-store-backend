using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class LanguageRepository : GenericRepository<string, LanguageEntity>
    {
        public LanguageRepository(BookStoreContext context) : base(context)
        {
        }

        public override async Task DeleteAsync(LanguageEntity entity)
        {
            await Task.Run(() =>
            {
                _entities.Attach(entity);
                entity.IsDeleted = true;
            });
        }
    }
}
