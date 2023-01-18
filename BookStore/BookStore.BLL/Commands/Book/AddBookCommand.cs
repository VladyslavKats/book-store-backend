using BookStore.BLL.Models.Book;
using MediatR;

namespace BookStore.BLL.Commands.Book
{
    public class AddBookCommand : IRequest<Unit>
    {
        public BookCreateDto Book { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Publisher { get; set; }

        public string Language { get; set; }

        public AddBookCommand(BookCreateDto book, 
            IEnumerable<string> genres,
            IEnumerable<string> authors,
            string language,
            string publisher)
        {
            Book = book;
            Genres = genres;
            Authors = authors;
            Language = language;
            Publisher = publisher;
        }
    }
}
