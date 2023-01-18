using AutoMapper;
using BookStore.BLL.Commands.Author;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Author
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public AddAuthorHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<AuthorEntity>(request.Author);
            await _context.Authors.AddAsync(author);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
