using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEcommerce.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).ValueGeneratedNever().HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(p => p.Description).ValueGeneratedNever().HasMaxLength(2000).IsUnicode(false).IsRequired(false);
        builder.Property(p => p.ImageUrl).ValueGeneratedNever().HasMaxLength(150).IsUnicode(false).IsRequired(false);
        builder.Property(p => p.Price).ValueGeneratedNever().HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(p => p.QuantityInStock).ValueGeneratedNever().HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(p => p.OnSale).HasMaxLength(1).IsUnicode(false).IsRequired();
        builder.Property(p => p.Discount).ValueGeneratedNever().HasMaxLength(3).IsUnicode(false).IsRequired();
        builder.Property(p => p.AddedDate).HasDefaultValueSql("getutcdate()").HasMaxLength(20).IsUnicode(false).IsRequired();
    }
}