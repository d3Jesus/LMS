﻿using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable(nameof(Stock));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BookId).IsRequired();
            builder.Property(p => p.NumberOfCopies).IsRequired().HasMaxLength(50);
            builder.Property(p => p.SalePrice).IsRequired().HasColumnType("numeric").HasPrecision(18, 2);
        }
    }
}
