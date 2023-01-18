using AutoMapper;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Models.Book;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Book
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken = default)
        {
            var book = await _context.Books.GetAsync(request.Id);
            if (book == null)
            {
                throw new EntityDoesNotExistException("Book with such id does not exist");
            }
            return _mapper.Map<BookDto>(book);
        }
    }
}
