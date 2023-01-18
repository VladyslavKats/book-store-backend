using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class LanguageRepository : GenericRepository<string, LanguageEntity>
    {
        public LanguageRepository(BookStoreContext context) : base(context)
        {
        }

        public override Task DeleteAsync(LanguageEntity entity)
        {
            _entities.Attach(entity);
            entity.IsDeleted = true;
            return Task.CompletedTask;
        }

        public override async Task<IEnumerable<LanguageEntity>> GetAllAsync(string includeProperies = "")
        {
            var languages = await base.GetAllAsync(includeProperies);
            return languages.Where(l => !l.IsDeleted);
        }
    }
}
