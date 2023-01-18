using MediatR;

namespace BookStore.BLL.Commands.Publisher
{
    public class DeletePublisherByIdCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public DeletePublisherByIdCommand(string id)
        {
            Id = id;
        }
    }
}
