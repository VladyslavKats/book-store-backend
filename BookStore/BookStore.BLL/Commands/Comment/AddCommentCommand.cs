using BookStore.BLL.Models.Comment;

namespace BookStore.BLL.Commands.Comment
{
    public class AddCommentCommand
    {
        public string UserId { get; set; }

        public CommentCreateDto Comment { get; set; }
        
        public AddCommentCommand(CommentCreateDto comment , string userId)
        {
            Comment = comment;
            UserId = userId;
        }
    }
}
