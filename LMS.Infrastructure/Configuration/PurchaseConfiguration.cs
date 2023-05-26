using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    internal class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable(nameof(Purchase));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.LibrarianId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DatePurchased).IsRequired();
            builder.Property(p => p.TotalPayed).HasPrecision(18,2).IsRequired();
        }
    }
}
