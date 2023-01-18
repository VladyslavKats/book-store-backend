using BookStore.BLL.Models.Book;
using MediatR;

namespace BookStore.BLL.Commands.Book
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public BookUpdateDto Book { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Publisher { get; set; }

        public string Language { get; set; }

        public UpdateBookCommand(BookUpdateDto book, IEnumerable<string> genres, IEnumerable<string> authors, string publisher, string language)
        {
            Book = book;
            Genres = genres;
            Authors = authors;
            Publisher = publisher;
            Language = language;
        }
    }
}
