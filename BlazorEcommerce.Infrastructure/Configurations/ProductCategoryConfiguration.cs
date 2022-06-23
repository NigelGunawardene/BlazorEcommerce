using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEcommerce.DataAccess.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.Property(pc => pc.Id).HasMaxLength(10);
        builder.Property(pc => pc.DisplayName).ValueGeneratedNever().HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(pc => pc.Value).ValueGeneratedNever().HasMaxLength(5).IsUnicode(false).IsRequired();
        builder.Property(pc => pc.IsActive).HasMaxLength(1).IsUnicode(false).IsRequired();
        builder.Property(pc => pc.IsFeatured).HasMaxLength(1).IsUnicode(false).IsRequired();

        builder.HasMany(pc => pc.Products).WithMany(p => p.Categories).UsingEntity(cp => cp.ToTable("ProductCategoryMapping"));
    }
}

