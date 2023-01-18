namespace BookStore.BLL.Models.Book
{
    public class BookCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int PublishedYear { get; set; }

        public int PageCount { get; set; }
    }
}
