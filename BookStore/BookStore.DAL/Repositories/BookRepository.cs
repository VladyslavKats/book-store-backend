using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repositories
{
    public class BookRepository : GenericRepository<string, BookEntity>
    {
        public BookRepository(BookStoreContext context) : base(context)
        {
        }

        public override Task<BookEntity> AddAsync(BookEntity entity)
        {
            foreach (var genre in entity.Genres)
            {
                _context.Entry(genre).State = EntityState.Unchanged;
            }
            foreach (var author in entity.Authors)
            {
                _context.Entry(author).State = EntityState.Unchanged;
            }
            if (entity.Language != null)
            {
                _context.Entry(entity.Language).State = EntityState.Unchanged;
            }
            if (entity.Publisher != null)
            {
                _context.Entry(entity.Publisher).State = EntityState.Unchanged;
            }
            return base.AddAsync(entity);
        }
    }
}
