using BookStore.DAL.Interfaces;

namespace BookStore.DAL.Entities
{
    public class AuthorEntity : IBaseEntity<string>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public ICollection<BookAuthorEntity> BookAuthor { get; set; }
    }
}
