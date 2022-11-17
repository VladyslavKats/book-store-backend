namespace BookStore.DAL.Entities
{
    public class OrderDetailEntity
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }

        public string BookId { get; set; }

        public string OrderId { get; set; }

        public BookEntity Book { get; set; }

        public OrderEntity Order { get; set; }
    }
}
