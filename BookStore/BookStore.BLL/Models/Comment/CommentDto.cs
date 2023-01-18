using BookStore.BLL.Models.Book;

namespace BookStore.BLL.Models.Comment
{
    public class CommentDto
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public string BookId { get; set; }

        public string ParentCommentId { get; set; }

        public BookDto Book { get; set; }

        public CommentDto ParentComment { get; set; }

        public ICollection<CommentDto> ChildrenComments { get; set; }
    }
}