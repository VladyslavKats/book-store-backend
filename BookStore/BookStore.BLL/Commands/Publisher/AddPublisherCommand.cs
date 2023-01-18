using BookStore.BLL.Models.Publisher;
using MediatR;

namespace BookStore.BLL.Commands.Publisher
{
    public class AddPublisherCommand : IRequest<Unit>
    {
        public PublisherCreateDto Publisher { get; set; }

        public AddPublisherCommand(PublisherCreateDto publisher)
        {
            Publisher = publisher;
        }
    }
}
