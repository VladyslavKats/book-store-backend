using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<LanguageEntity>
    {
        public void Configure(EntityTypeBuilder<LanguageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasIndex(x => x.Name)
                .IsUnique();
            builder
                .HasMany(x => x.Books)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.LanguageId);
        }
    }
}
