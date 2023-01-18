using BookStore.BLL.Models.Publisher;
using MediatR;

namespace BookStore.BLL.Commands.Publisher
{
    public class UpdatePublisherCommand : IRequest<Unit>
    {
        public PublisherUpdateDto Publisher { get; set; }

        public UpdatePublisherCommand(PublisherUpdateDto publisher)
        {
            Publisher = publisher;
        }
    }
}
