using BookStore.BLL.Models.Book;
using MediatR;

namespace BookStore.BLL.Queries.Book
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }
}
