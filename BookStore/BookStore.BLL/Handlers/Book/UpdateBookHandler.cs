using AutoMapper;
using BookStore.BLL.Commands.Book;
using BookStore.BLL.Exceptions;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using MediatR;

namespace BookStore.BLL.Handlers.Book
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand,Unit>
    {
        private readonly IBookStoreUW _context;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookStoreUW context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken = default)
        {
            var bookExist = await _context.Books.GetAsync(request.Book.Id);
            if (bookExist == null)
            {
                throw new EntityDoesNotExistException("Book with such id does not exist");
            }
            var bookToUpdate = _mapper.Map<BookEntity>(request.Book);
            await AddAuthorsToBookAsync(bookToUpdate , request.Authors);
            await AddGenresToBookAsync(bookToUpdate, request.Genres);
            await AddLanguageToBookAsync(bookToUpdate,request.Language);
            await AddPublisherToBookAsync(bookToUpdate,request.Publisher);
            await _context.Books.UpdateAsync(bookToUpdate);
            await _context.CommitAsync(cancellationToken);
            return Unit.Value;
        }

        private async Task AddGenresToBookAsync(BookEntity book , IEnumerable<string> genreIds)
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

        private async Task AddAuthorsToBookAsync(BookEntity book , IEnumerable<string> authorIds)
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

        private async Task AddLanguageToBookAsync(BookEntity book , string languageId)
        {
            var language = await _context.Languages.GetAsync(languageId);
            if (language == null)
            {
                throw new EntityDoesNotExistException("Language with such id does not exist");
            }
            book.LanguageId = languageId;
        }

        private async Task AddPublisherToBookAsync(BookEntity book , string publisherId)
        {
            var publisher = await _context.Publishers.GetAsync(publisherId);
            if (publisher == null)
            {
                throw new EntityDoesNotExistException("Publisher with such id does not exist");
            }
            book.PublisherId = publisherId;
        }
    }
}
