using BookStore.BLL.Models.Book;

namespace BookStore.BLL.Models.Genre
{
    public class GenreDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentGenreId { get; set; }

        public GenreDto ParentGenre { get; set; }

        public ICollection<GenreDto> ChildrenGenres { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}