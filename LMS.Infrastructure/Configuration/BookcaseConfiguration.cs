using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class BookcaseConfiguration : IEntityTypeConfiguration<Bookcase>
    {
        public void Configure(EntityTypeBuilder<Bookcase> builder)
        {
            builder.ToTable(nameof(Bookcase));
            builder.Property(p => p.Id);
            builder.Property(p => p.Section).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Hall).IsRequired().HasMaxLength(50);

        }
    }
}
