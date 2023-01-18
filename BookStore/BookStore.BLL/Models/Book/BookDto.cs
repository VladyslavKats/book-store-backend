using BookStore.BLL.Models.Author;
using BookStore.BLL.Models.Comment;
using BookStore.BLL.Models.Genre;
using BookStore.BLL.Models.Language;
using BookStore.BLL.Models.Publisher;

namespace BookStore.BLL.Models.Book
{
    public class BookDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ViewCount { get; set; }

        public string ImageUrl { get; set; }

        public int PublishedYear { get; set; }

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public long Evaluaions { get; set; }

        public string LanguageId { get; set; }

        public string PublisherId { get; set; }

        public LanguageDto Language { get; set; }

        public ICollection<AuthorDto> Authors { get; set; }

        public ICollection<CommentDto> Comments { get; set; }

        public ICollection<OrderDetailDto> OrderDetails { get; set; }

        public ICollection<GenreDto> Genres { get; set; }

        public PublisherDto Publisher { get; set; }
    }
}
