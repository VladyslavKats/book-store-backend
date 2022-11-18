using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repositories
{
    public class CommentRepository : GenericRepository<string, CommentEntity>
    {
        public CommentRepository(BookStoreContext context) : base(context)
        {
        }

        public override async Task DeleteAsync(CommentEntity entity)
        {
            var childrenComments = await _entities
                .Where(c => c.ParentCommentId == entity.Id)
                .ToListAsync();
            if (childrenComments.Count != 0)
            {
                foreach (var comment in childrenComments)
                {
                    await DeleteAsync(comment);
                }
            }
            await base.DeleteAsync(entity);
        }
    }
}
