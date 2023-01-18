using BookStore.BLL.Models.Book;

namespace BookStore.BLL.Models.Language
{
    public class LanguageDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}