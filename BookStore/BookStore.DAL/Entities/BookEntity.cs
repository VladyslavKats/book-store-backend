using BookStore.DAL.Interfaces;

namespace BookStore.DAL.Entities
{
    public class BookEntity : EntityWithCreatedAtField , IBaseEntity<string>
    {
        public BookEntity()
        {
            Genres = new List<GenreEntity>();
            Authors = new List<AuthorEntity>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ViewCount { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public int PublishedYear { get; set; }

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public long Evaluaions { get; set; }

        public string LanguageId { get; set; }

        public string PublisherId { get; set; }

        public LanguageEntity Language { get; set; }

        public ICollection<AuthorEntity> Authors { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

        public ICollection<BookAuthorEntity> BookAuthor { get; set; }

        public ICollection<BookGenreEntity> BookGenre { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; }

        public ICollection<GenreEntity> Genres { get; set; }

        public PublisherEntity Publisher { get; set; }
    }
}
