using BookStore.BLL.Models.Publisher;
using MediatR;

namespace BookStore.BLL.Queries.Publisher
{
    public class GetAllPublishersQuery : IRequest<IEnumerable<PublisherDto>>
    {
    }
}
