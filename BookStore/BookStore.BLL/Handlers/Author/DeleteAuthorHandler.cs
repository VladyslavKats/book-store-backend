using AutoMapper;
using BookStore.BLL.Commands.Author;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Author
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorByIdCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public DeleteAuthorHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.GetAsync(request.Id);
            if (author == null)
            {
                throw new EntityDoesNotExistException("Author with such id does not exist");
            }
            await _context.Authors.DeleteAsync(author);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
