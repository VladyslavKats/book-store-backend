using AutoMapper;
using BookStore.BLL.Models.Publisher;
using BookStore.BLL.Queries.Publisher;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Publisher
{
    public class GetAllPublishersHandler : IRequestHandler<GetAllPublishersQuery,IEnumerable<PublisherDto>>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetAllPublishersHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublisherDto>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken = default)
        {
            var publishers = await _context.Publishers.GetAllAsync();
            return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
        }
    }
}
