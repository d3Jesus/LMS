using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable(nameof(Reservation));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.BookId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.MemberId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ReservationStatus).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ReservationDate).IsRequired().HasMaxLength(50);
        }
    }
}
