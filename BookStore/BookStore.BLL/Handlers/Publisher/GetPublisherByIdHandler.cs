using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Models.Publisher;
using BookStore.BLL.Queries.Publisher;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Publisher
{
    public class GetPublisherByIdHandler : IRequestHandler<GetPublisherByIdQuery,PublisherDto>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;


        public GetPublisherByIdHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PublisherDto> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken = default)
        {
            var publisher = await _context.Publishers.GetAsync(request.Id);
            if (publisher == null)
            {
                throw new EntityDoesNotExistException("Publisher with such id does not exist");
            }
            return _mapper.Map<PublisherDto>(publisher);
        }
    }
}
