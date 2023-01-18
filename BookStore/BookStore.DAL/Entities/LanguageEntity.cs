using BookStore.DAL.Interfaces;

namespace BookStore.DAL.Entities
{
    public class LanguageEntity : IBaseEntity<string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BookEntity> Books { get; set; }
    }
}
