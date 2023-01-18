using BookStore.BLL.Models.Book;
using MediatR;

namespace BookStore.BLL.Queries.Book
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public string Id { get; set; }

        public GetBookByIdQuery(string id)
        {
            Id = id;
        }
    }
}
