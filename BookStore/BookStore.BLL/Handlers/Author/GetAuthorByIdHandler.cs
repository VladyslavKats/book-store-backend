using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Models.Author;
using BookStore.BLL.Queries.Author;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Author
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery,AuthorDto>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetAuthorByIdHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken = default)
        {
            var author = await _context.Authors.GetAsync(request.Id);
            if (author == null)
            {
                throw new EntityDoesNotExistException("Author with such id does not exist");
            }
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
