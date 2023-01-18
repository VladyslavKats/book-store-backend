using BookStore.BLL.Models.Genre;
using MediatR;

namespace BookStore.BLL.Queries.Genre
{
    public class GetSubGenresQuery : IRequest<IEnumerable<GenreDto>>
    {
        public string ParentGenreId { get; set; }

        public GetSubGenresQuery(string parentGenreId)
        {
            ParentGenreId = parentGenreId;
        }
    }
}
