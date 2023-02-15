using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class PublishingCompanyConfiguration : IEntityTypeConfiguration<PublishingCompany>
    {
        public void Configure(EntityTypeBuilder<PublishingCompany> builder)
        {
            builder.ToTable(nameof(PublishingCompany));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        }
    }
}
