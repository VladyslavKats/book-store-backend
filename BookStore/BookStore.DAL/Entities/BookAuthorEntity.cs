namespace BookStore.DAL.Entities
{
    public class BookAuthorEntity
    {
        public string BookId { get; set; }

        public BookEntity Book { get; set; }

        public string AuthorId { get; set; }

        public AuthorEntity Author { get; set; }
    }
}
