using AutoMapper;
using BookStore.BLL.Commands.Author;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;
using System;

namespace BookStore.BLL.Handlers.Author
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public UpdateAuthorHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken = default)
        {
            var author = _mapper.Map<AuthorEntity>(request.Author);
            var authorExist = await _context.Authors.GetAsync(request.Author.Id);
            if (authorExist == null)
            {
                throw new EntityDoesNotExistException("Author with such id does not exist");
            }
            await _context.Authors.UpdateAsync(author);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
