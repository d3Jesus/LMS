using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Configuration
{
    public class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.ToTable(nameof(Librarian));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(p => p.WasDeleted).HasDefaultValue(false);
        }
    }
}
