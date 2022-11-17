namespace BookStore.DAL.Entities
{
    public class LanguageEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BookEntity> Books { get; set; }
    }
}
