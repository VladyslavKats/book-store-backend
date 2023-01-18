using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations
{
    internal class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasIndex(x => x.Name)
                .IsUnique();
            builder
                .HasOne(x => x.ParentGenre)
                .WithMany(x => x.ChildrenGenres)
                .HasForeignKey(x => x.ParentGenreId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
