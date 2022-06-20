using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEcommerce.DataAccess.Configurations;

public class WishlistProductConfiguration : IEntityTypeConfiguration<WishlistProduct>
{
    public void Configure(EntityTypeBuilder<WishlistProduct> builder)
    {
        builder.Property(wp => wp.UserId).HasMaxLength(10).IsUnicode(false).IsRequired();
        builder.Property(wp => wp.ProductId).HasMaxLength(10).IsUnicode(false).IsRequired();
        builder.Property(wp => wp.AddedDate).HasDefaultValueSql("getutcdate()").HasMaxLength(20).IsUnicode(false).IsRequired();

        builder.HasOne(wp => wp.User).WithMany(u => u.WishlistProducts).HasForeignKey(wp => wp.UserId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        builder.HasOne(wp => wp.Product).WithMany(p => p.WishlistProducts).HasForeignKey(wp => wp.ProductId).OnDelete(DeleteBehavior.Restrict).IsRequired();
    }
}

