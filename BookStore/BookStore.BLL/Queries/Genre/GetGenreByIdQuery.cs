using BookStore.BLL.Models.Genre;
using MediatR;

namespace BookStore.BLL.Queries.Genre
{
    public class GetGenreByIdQuery : IRequest<GenreDto>
    {
        public string Id { get; set; }

        public GetGenreByIdQuery(string id)
        {
            Id = id;
        }
    }
}
