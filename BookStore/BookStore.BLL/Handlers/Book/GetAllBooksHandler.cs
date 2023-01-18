using AutoMapper;
using BookStore.BLL.Models.Book;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Book
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken = default)
        {
            var books = await _context.Books.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
