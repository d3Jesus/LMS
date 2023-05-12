using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable(nameof(Stock));
            builder.HasKey(p => p.Book);
            builder.Property(p => p.Book).IsRequired();
            builder.Property(p => p.NumberOfCopies).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CopiesAvailable).IsRequired().HasMaxLength(50);

        }
    }
}
