using BookStore.BLL.Models.Genre;
using MediatR;

namespace BookStore.BLL.Commands.Genre
{
    public class AddGenreCommand : IRequest<Unit>
    {
        public GenreCreateDto Genre { get; set; }

        public AddGenreCommand(GenreCreateDto genre)
        {
            Genre = genre;
        }
    }
}
