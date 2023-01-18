using MediatR;

namespace BookStore.BLL.Commands.Author
{
    public class DeleteAuthorByIdCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public DeleteAuthorByIdCommand(string id)
        {
            Id = id;
        }
    }
}
