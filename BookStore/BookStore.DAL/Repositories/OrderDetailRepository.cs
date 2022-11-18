using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class OrderDetailRepository : GenericRepository<string, OrderDetailEntity>
    {
        public OrderDetailRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
