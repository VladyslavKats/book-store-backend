namespace BookStore.DAL.Entities
{
    public class GenreEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentGenreId { get; set; }

        public GenreEntity ParentGenre { get; set; }

        public ICollection<GenreEntity> ChildrenGenres { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public ICollection<BookGenreEntity> BookGenre { get; set; }
    }
}
