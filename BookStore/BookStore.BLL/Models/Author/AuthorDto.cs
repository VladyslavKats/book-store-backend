using BookStore.BLL.Models.Book;

namespace BookStore.BLL.Models.Author
{
    public class AuthorDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}