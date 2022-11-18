using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class OrderRepository : GenericRepository<string, OrderEntity>
    {
        public OrderRepository(BookStoreContext context) : base(context)
        {
        }

        public override async Task DeleteAsync(OrderEntity entity)
        {
            await Task.Run(() =>
            {
                _entities.Attach(entity);
                entity.IsDeleted = true;
            });
        }
    }
}
