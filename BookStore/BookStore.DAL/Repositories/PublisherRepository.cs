using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class PublisherRepository : GenericRepository<string, PublisherEntity>
    {
        public PublisherRepository(BookStoreContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<PublisherEntity>> GetAllAsync(string includeProperies = "")
        {
            var publishers = await base.GetAllAsync(includeProperies);
            return publishers.Where(p => !p.IsDeleted);
        }

        public override Task DeleteAsync(PublisherEntity entity)
        {
            _entities.Attach(entity);
            entity.IsDeleted = true;
            return Task.CompletedTask;
        }
    }
}
