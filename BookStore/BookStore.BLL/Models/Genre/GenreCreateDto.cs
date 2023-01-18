namespace BookStore.BLL.Models.Genre
{
    public class GenreCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentGenreId { get; set; }
    }
}
