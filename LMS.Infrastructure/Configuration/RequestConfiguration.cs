using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    internal class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable(nameof(Request));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.RequestDate).IsRequired();
            builder.Property(p => p.ReturnDate).IsRequired();
            builder.Property(p => p.BookId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ReaderId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.NumberOfCopies).IsRequired().HasMaxLength(50);
            builder.Property(p => p.WasReturned).IsRequired();
        }
    }
}
