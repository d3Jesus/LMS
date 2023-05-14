using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Edition).IsRequired();
            builder.Property(p => p.ISBN).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateCreated).IsRequired().HasMaxLength(50);
        }
    }
}
