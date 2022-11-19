using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Repositories;

namespace BookStore.DAL
{
    public class BookStoreUW : IBookStoreUW
    {
        private bool _disposed;
        private  BookStoreContext _context;
        private IRepository<string, BookEntity> _bookRepository;
        private IRepository<string, AuthorEntity> _authorRepository;
        private IRepository<string, GenreEntity> _genreRepository;
        private IRepository<string, CommentEntity> _commentRepository;
        private IRepository<string, LanguageEntity> _languageRepository;
        private IRepository<string, OrderEntity> _orderRepository;
        private IRepository<string, OrderDetailEntity> _orderDetailRepository;

        public BookStoreUW(BookStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IRepository<string, BookEntity> Books => _bookRepository ??=
            new BookRepository(_context);
        public IRepository<string, AuthorEntity> Authors => _authorRepository ??= 
            new AuthorRepository(_context);
        public IRepository<string, GenreEntity> Genres => _genreRepository ??= 
            new GenreRepository(_context);
        public IRepository<string, CommentEntity> Comments => _commentRepository ??= 
            new CommentRepository(_context);
        public IRepository<string, LanguageEntity> Languages => _languageRepository ??= 
            new LanguageRepository(_context);
        public IRepository<string, OrderEntity> Orders => _orderRepository ??=
            new OrderRepository(_context);
        public IRepository<string, OrderDetailEntity> OrderDetails => _orderDetailRepository ??= 
            new OrderDetailRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
