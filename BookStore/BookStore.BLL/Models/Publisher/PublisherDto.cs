using BookStore.BLL.Models.Book;

namespace BookStore.BLL.Models.Publisher
{
    public class PublisherDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}
