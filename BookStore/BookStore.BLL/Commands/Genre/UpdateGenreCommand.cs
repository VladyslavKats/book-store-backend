using BookStore.BLL.Models.Genre;
using MediatR;

namespace BookStore.BLL.Commands.Genre
{
    public class UpdateGenreCommand : IRequest<Unit>
    {
        public GenreUpdateDto Genre { get; set; }
    }
}
