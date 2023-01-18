namespace BookStore.BLL.Models.Comment
{
    public class CommentCreateDto
    {
        public string Text { get; set; }

        public string BookId { get; set; }

        public string ParentCommentId { get; set; }
    }
}
