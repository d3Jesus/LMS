using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    internal class PurchaseItemsConfiguration : IEntityTypeConfiguration<PurchaseItems>
    {
        public void Configure(EntityTypeBuilder<PurchaseItems> builder)
        {
            builder.ToTable(nameof(PurchaseItems));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.PurchasedId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.BookId).IsRequired();
            builder.Property(p => p.NumberOfCopies).IsRequired();
            builder.Property(p => p.BasePrice).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.PurchasedPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
