using AutoMapper;
using BookStore.BLL.Models.Author;
using BookStore.BLL.Queries.Author;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Author
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery,IEnumerable<AuthorDto>>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetAllAuthorsHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _context.Authors.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }
    }
}
