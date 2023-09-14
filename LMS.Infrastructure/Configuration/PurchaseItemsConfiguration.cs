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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PurchaseId).IsRequired();
            builder.Property(p => p.BookId).IsRequired();
            builder.Property(p => p.NumberOfCopies).IsRequired();
            builder.Property(p => p.UnitPrice).HasColumnType("numeric").HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.GrossPrice).HasColumnType("numeric").HasPrecision(18, 2).IsRequired();
            
            builder.HasOne(e => e.Purchase)
                .WithMany(e => e.PurchaseItems)
                .HasForeignKey(e => e.PurchaseId);
        }
    }
}
