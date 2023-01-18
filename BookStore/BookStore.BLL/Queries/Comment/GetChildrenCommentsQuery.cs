using BookStore.BLL.Models.Comment;
using MediatR;

namespace BookStore.BLL.Queries.Comment
{
    public class GetChildrenCommentsQuery : IRequest<IEnumerable<CommentDto>>
    {

    }
}
