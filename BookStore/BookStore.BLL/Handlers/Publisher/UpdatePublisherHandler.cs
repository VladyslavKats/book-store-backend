using AutoMapper;
using BookStore.BLL.Commands.Publisher;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Publisher
{
    public class UpdatePublisherHandler : IRequestHandler<UpdatePublisherCommand, Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public UpdatePublisherHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken = default)
        {
            var publisherExist = await _context.Publishers.GetAsync(request.Publisher.Id);
            if (publisherExist == null)
            {
                throw new EntityDoesNotExistException("Publisher with such id does not exist");
            }
            var publisher = _mapper.Map<PublisherEntity>(request.Publisher);
            await _context.Publishers.UpdateAsync(publisher);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
