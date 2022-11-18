using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repositories
{
    public class GenreRepository : GenericRepository<string, GenreEntity>
    {
        public GenreRepository(BookStoreContext context) : base(context)
        {
        }

        public override async Task DeleteAsync(GenreEntity entity)
        {
            var subGenres = await _entities
                .Where(g => g.ParentGenreId == entity.Id)
                .ToListAsync();
            if (subGenres.Count != 0)
            {
                foreach (var genre in subGenres)
                {
                    await DeleteAsync(genre);
                }
            }
            await base.DeleteAsync(entity);    
        }
    }
}
