using BookStore.DAL.Entities;

namespace BookStore.DAL.Interfaces
{
    public interface IBookStoreUW : IDisposable
    {
        public IRepository<string,BookEntity> Books { get; }

        public IRepository<string,AuthorEntity> Authors { get; }

        public IRepository<string , GenreEntity> Genres { get; }

        public IRepository<string , CommentEntity> Comments { get; }

        public IRepository<string , LanguageEntity> Languages { get; }

        public IRepository<string , OrderEntity> Orders { get; }

        public IRepository<string , OrderDetailEntity> OrderDetails { get; }

        Task CommitAsync();
    }
}
