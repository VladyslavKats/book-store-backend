namespace BookStore.BLL.Handlers.Book
{
    public class BookGetModel
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
    }
}
