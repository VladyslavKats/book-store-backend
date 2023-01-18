using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity>
    {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasMany(x => x.Books)
                .WithOne(x => x.Publisher)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
