using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LMS.CoreBusiness.Entities;

namespace LMS.Infrastructure.Configurations;

public class AcquisitionConfiguration : IEntityTypeConfiguration<Acquisition>
{
    public void Configure(EntityTypeBuilder<Acquisition> builder)
    {
        builder.ToTable("Acquisitions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LibrarianId).IsRequired();
        builder.Property(x => x.DateRegistered).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(10).IsRequired();
    }
}
