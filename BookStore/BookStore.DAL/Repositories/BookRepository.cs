using BookStore.DAL.EF;
using BookStore.DAL.Entities;

namespace BookStore.DAL.Repositories
{
    public class BookRepository : GenericRepository<string, BookEntity>
    {
        public BookRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
