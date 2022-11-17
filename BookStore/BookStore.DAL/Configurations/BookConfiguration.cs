using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Genres)
                .WithMany(x => x.Books)
                .UsingEntity<BookGenreEntity>(
                    j => j
                        .HasOne(x => x.Genre)
                        .WithMany(x => x.BookGenre)
                        .HasForeignKey(x => x.GenreId),
                    j => j
                        .HasOne(x => x.Book)
                        .WithMany(x => x.BookGenre)
                        .HasForeignKey(x => x.BookId),
                    j => j
                        .HasKey(x => new {x.BookId , x.GenreId})
                );
            builder
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books)
                .UsingEntity<BookAuthorEntity>(
                    j => j
                        .HasOne(x => x.Author)
                        .WithMany(x => x.BookAuthor)
                        .HasForeignKey(x => x.AuthorId),
                    j => j
                        .HasOne(x => x.Book)
                        .WithMany(x => x.BookAuthor)
                        .HasForeignKey(x => x.BookId),
                    j => j
                        .HasKey(x => new { x.BookId, x.AuthorId })
                );
        }
    }
}
