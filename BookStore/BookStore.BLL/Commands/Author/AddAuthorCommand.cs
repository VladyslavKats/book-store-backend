using BookStore.BLL.Models.Author;
using MediatR;

namespace BookStore.BLL.Commands.Author
{
    public class AddAuthorCommand : IRequest<Unit>
    {
        public AuthorCreateDto Author { get; set; }

        public AddAuthorCommand(AuthorCreateDto author)
        {
            Author = author;
        }
    }
}
