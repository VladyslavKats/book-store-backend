using AutoMapper;
using BookStore.BLL.Commands.Book;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Book
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public AddBookHandler(IBookStoreUW context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddBookCommand request, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<BookEntity>(request.Book);
            await AddGenresAsync(book , request.Genres);
            await AddAuthorsAsync(book,request.Authors);
            await AddLanguageAsync(book,request.Language);
            await AddPublisherAsync(book,request.Publisher);
            await _context.Books.AddAsync(book);
            await _context.CommitAsync();
            return Unit.Value;
        }

        private async Task AddLanguageAsync(BookEntity book, string languageId)
        {
            var language = await _context.Languages.GetAsync(languageId);
            if (language == null)
            {
                throw new EntityDoesNotExistException("Language with such id does not exist");
            }
            book.LanguageId = languageId;
            book.Language = language;
        }

        private async Task AddGenresAsync(BookEntity book ,IEnumerable<string> genreIds)
        {
            foreach (var genreId in genreIds)
            {
                var genre = await _context.Genres.GetAsync(genreId);
                if (genre == null)
                {
                    throw new EntityDoesNotExistException("Genre with such id does not exist");
                }
                book.Genres.Add(genre);
            }
        }

        private async Task AddAuthorsAsync(BookEntity book, IEnumerable<string> authorIds)
        {
            foreach (var authorId in authorIds)
            {
                var author = await _context.Authors.GetAsync(authorId);
                if (author == null)
                {
                    throw new EntityDoesNotExistException("Author with such id does not exist");
                }
                book.Authors.Add(author);
            }
        }

        private async Task AddPublisherAsync(BookEntity book ,string publisherId)
        {
            var publisher = await _context.Publishers.GetAsync(publisherId);
            if (publisher == null)
            {
                throw new EntityDoesNotExistException("Publisher with such id does not exist");
            }
            book.PublisherId = publisherId;
            book.Publisher = publisher;
        }
    }
}
