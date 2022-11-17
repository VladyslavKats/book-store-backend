using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BookId);
            builder
                .HasOne(x => x.ParentComment)
                .WithMany(x => x.ChildrenComments)
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
