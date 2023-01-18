using MediatR;

namespace BookStore.BLL.Commands.Book
{
    public class DeleteBookByIdCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public DeleteBookByIdCommand(string id)
        {
            Id = id;
        }
    }
}
