using BookStore.BLL.Models.Author;
using MediatR;

namespace BookStore.BLL.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        public AuthorUpdateDto Author { get; set; }

        public UpdateAuthorCommand(AuthorUpdateDto author)
        {
            Author = author;
        }
    }
}
