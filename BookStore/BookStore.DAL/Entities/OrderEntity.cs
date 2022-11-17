namespace BookStore.DAL.Entities
{
    public class OrderEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
