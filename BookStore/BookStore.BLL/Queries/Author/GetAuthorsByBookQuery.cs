using BookStore.BLL.Models.Author;
using MediatR;

namespace BookStore.BLL.Queries.Author
{
    public class GetAuthorsByBookQuery : IRequest<IEnumerable<AuthorDto>>
    {
        public string BookId { get; set; }

        public GetAuthorsByBookQuery(string bookId)
        {
            BookId = bookId;
        }
    }
}
