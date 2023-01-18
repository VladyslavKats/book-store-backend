using BookStore.BLL.Models.Genre;
using MediatR;

namespace BookStore.BLL.Queries.Genre
{
    public class GetAllGenresQuery : IRequest<IEnumerable<GenreDto>>
    {
    }
}
