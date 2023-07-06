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
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Edition).IsRequired();
            builder.Property(p => p.ISBN).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateCreated).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).IsRequired().HasColumnType("numeric").HasPrecision(18, 2);
            
            builder.Ignore(p => p.Categories);
            builder.Ignore(p => p.ListOfAuthors);
            builder.Ignore(p => p.Author);
            builder.Ignore(p => p.Authorships);
            builder.Ignore(p => p.Authors);

            builder.HasMany(x => x.ListOfAuthors).WithMany(x => x.Books)
                    .UsingEntity<Authorship>(
                    r => r.HasOne(x => x.Authors).WithMany().HasForeignKey(x => x.AuthorId),
                    l => l.HasOne(x => x.Books).WithMany().HasForeignKey(x => x.BookId)); 
        }
    }
}
