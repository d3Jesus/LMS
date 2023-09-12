using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configurations;

public class AcquisitionItemsConfiguration : IEntityTypeConfiguration<AcquisitionItems>
{
    public void Configure(EntityTypeBuilder<AcquisitionItems> builder)
    {
        builder.ToTable("AcquisitionItems");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.AcquisitionId).IsRequired();
        builder.Property(b => b.BookId).IsRequired();
        builder.Property(b => b.Quantity).IsRequired();
        builder.Property(b => b.PurchasePrice).IsRequired().HasColumnType("numeric").HasPrecision(18, 2);
        builder.Property(b => b.SalePrice).IsRequired().HasColumnType("numeric").HasPrecision(18, 2);
    }
}
