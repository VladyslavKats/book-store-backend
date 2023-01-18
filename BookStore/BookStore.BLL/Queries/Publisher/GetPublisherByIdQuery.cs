using BookStore.BLL.Models.Publisher;
using MediatR;

namespace BookStore.BLL.Queries.Publisher
{
    public class GetPublisherByIdQuery : IRequest<PublisherDto>
    {
        public string Id { get; set; }

        public GetPublisherByIdQuery(string id)
        {
            Id = id;
        }
    }
}
