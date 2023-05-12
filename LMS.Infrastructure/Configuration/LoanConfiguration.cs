using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    internal class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable(nameof(Loan));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.BookId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.MemberId).IsRequired();
            builder.Property(p => p.NumberOfCopies).IsRequired();
            builder.Property(p => p.LoanDate).IsRequired().HasMaxLength(50);
            builder.Property(p => p.WasReturned).IsRequired();
            builder.Property(p => p.DateReturned).IsRequired().HasMaxLength(50);
        }
    }
}
