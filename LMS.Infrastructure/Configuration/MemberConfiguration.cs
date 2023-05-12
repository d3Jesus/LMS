using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable(nameof(Member));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DocNumber).IsRequired().HasMaxLength(13);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(9);
            builder.Property(p => p.WasDeleted).HasDefaultValue(false);
        }
    }
}
