namespace BookStore.BLL.Models.Book
{
    public class BookUpdateDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int PageCount { get; set; }
    }
}
