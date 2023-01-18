using MediatR;

namespace BookStore.BLL.Commands.Genre
{
    public class DeleteGenreByIdCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public DeleteGenreByIdCommand(string id)
        {
            Id = id;
        }
    }
}
