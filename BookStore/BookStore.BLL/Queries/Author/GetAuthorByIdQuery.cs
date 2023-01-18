using BookStore.BLL.Models.Author;
using MediatR;

namespace BookStore.BLL.Queries.Author
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public string Id { get; set; }

        public GetAuthorByIdQuery(string id)
        {
            Id = id;
        }
    }
}
