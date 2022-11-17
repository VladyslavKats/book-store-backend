namespace BookStore.DAL.Entities
{
    public class BookGenreEntity
    {
        public string BookId { get; set; }

        public BookEntity Book { get; set; }

        public string GenreId { get; set; }

        public GenreEntity Genre { get; set; }
    }
}
