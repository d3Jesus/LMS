using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Nationality).IsRequired().HasMaxLength(50);
            builder.Property(p => p.WasDeleted).HasDefaultValue(false);

            builder.Ignore(p => p.Authorships);
            builder.Ignore(p => p.Books);

            builder.HasMany(x => x.Books).WithMany(x => x.ListOfAuthors)
                    .UsingEntity<Authorship>(
                    r => r.HasOne(x => x.Books).WithMany().HasForeignKey(x => x.BookId),
                    l => l.HasOne(x => x.Authors).WithMany().HasForeignKey(x => x.AuthorId)); 
        }
    }
}
