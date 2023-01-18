using BookStore.BLL.Models.Author;
using MediatR;

namespace BookStore.BLL.Queries.Author
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
    {
    }
}
