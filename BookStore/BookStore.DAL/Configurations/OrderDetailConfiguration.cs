using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);
            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.BookId);
        }
    }
}
