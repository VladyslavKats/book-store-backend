using BookStore.DAL.Interfaces;

namespace BookStore.DAL.Entities
{
    public class CommentEntity : EntityWithCreatedAtField, IBaseEntity<string>
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public string BookId { get; set; }

        public string ParentCommentId { get; set; }

        public BookEntity Book { get; set; }

        public CommentEntity ParentComment { get; set; }

        public ICollection<CommentEntity> ChildrenComments { get; set; }
    }
}
