using LMS.CoreBusiness.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class GetBookViewModelConfiguration : IEntityTypeConfiguration<GetBookViewModel>
    {
        public void Configure(EntityTypeBuilder<GetBookViewModel> builder)
        {
            builder.ToTable("VwBook");
            builder.Property(p => p.id).IsRequired();
            builder.Property(p => p.title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.edition).IsRequired();
            builder.Property(p => p.isbn).IsRequired().HasMaxLength(50);
            builder.Property(p => p.categoryName).IsRequired();
            builder.Property(p => p.imageUrl).IsRequired().HasMaxLength(50);
            builder.Property(p => p.dateCreated).IsRequired().HasMaxLength(50);
            builder.Property(p => p.price).IsRequired().HasColumnType("numeric").HasPrecision(18, 2);
        }
    }
}
