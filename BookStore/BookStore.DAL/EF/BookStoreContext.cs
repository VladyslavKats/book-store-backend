using BookStore.DAL.Configurations;
using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.EF
{
    public class BookStoreContext : IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BookEntity> Books { get; set; }

        public DbSet<AuthorEntity> Authors { get; set; }

        public DbSet<GenreEntity> Genres { get; set; }

        public DbSet<LanguageEntity> Languages { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<PublisherEntity> Publishers { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCreatedAtField<BookEntity>();
            SetCreatedAtField<CommentEntity>();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetCreatedAtField<TEntity>() where TEntity : EntityWithCreatedAtField
        {
            var entities = ChangeTracker
                .Entries<TEntity>()
                .Where(e => e.State == EntityState.Added);
            foreach (var entity in entities)
            {
                entity.Entity.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}
