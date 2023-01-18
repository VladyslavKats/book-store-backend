using AutoMapper;
using BookStore.BLL.Commands.Publisher;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Publisher
{
    public class DeletePublisherByIdHandler : IRequestHandler<DeletePublisherByIdCommand,Unit>
    {
        private readonly IBookStoreUW _context;

        public DeletePublisherByIdHandler(IBookStoreUW context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePublisherByIdCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _context.Publishers.GetAsync(request.Id);
            if (publisher == null)
            {
                throw new EntityDoesNotExistException("Publisher with such id does not exist");
            }
            await _context.Publishers.DeleteAsync(publisher);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
