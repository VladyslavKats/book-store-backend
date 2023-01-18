using AutoMapper;
using BookStore.BLL.Commands.Publisher;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Publisher
{
    public class AddPublisherHandler : IRequestHandler<AddPublisherCommand, Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public AddPublisherHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddPublisherCommand request, CancellationToken cancellationToken = default)
        {
            var publisher = _mapper.Map<PublisherEntity>(request.Publisher);
            await _context.Publishers.AddAsync(publisher);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
