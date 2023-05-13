using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class VwReservationConfiguration : IEntityTypeConfiguration<VwReservation>
    {
        public void Configure(EntityTypeBuilder<VwReservation> builder)
        {
            builder.ToTable(nameof(VwReservation));
            builder.HasKey(e => e.ReservationId);
            builder.Property(p => p.ReservationId).IsRequired();
            builder.Property(p => p.BookTitle).IsRequired().HasMaxLength(50);
            builder.Property(p => p.MemberName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateCreated).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ReservationStatus).IsRequired().HasMaxLength(50);
        }
    }
}
