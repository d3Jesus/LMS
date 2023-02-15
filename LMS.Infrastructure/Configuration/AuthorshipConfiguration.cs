﻿using LMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Configuration
{
    public class AuthorshipConfiguration : IEntityTypeConfiguration<Authorship>
    {
        public void Configure(EntityTypeBuilder<Authorship> builder)
        {
            builder.ToTable(nameof(Authorship));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.AuthorId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.BookId).IsRequired().HasMaxLength(50);
        }
    }
}
