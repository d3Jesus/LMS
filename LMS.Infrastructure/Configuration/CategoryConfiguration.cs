using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CategoryName).IsRequired().HasMaxLength(50);
        }
    }
}
