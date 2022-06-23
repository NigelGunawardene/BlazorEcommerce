using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEcommerce.DataAccess.Configurations;

public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
{
    public void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        builder.Property(cp => cp.Id).HasMaxLength(10);
        builder.Property(cp => cp.ProductId).ValueGeneratedNever().HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(cp => cp.UserId).ValueGeneratedNever().HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(cp => cp.Quantity).ValueGeneratedNever().HasMaxLength(3).IsUnicode(false).IsRequired();
        builder.Property(cp => cp.AddedDate).HasDefaultValueSql("getutcdate()").HasMaxLength(20).IsUnicode(false).IsRequired();

        builder.HasOne(cp => cp.User).WithMany(u => u.CartProducts).HasForeignKey(cp => cp.UserId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        builder.HasOne(cp => cp.Product).WithMany(p => p.CartProducts).HasForeignKey(cp => cp.ProductId).OnDelete(DeleteBehavior.Restrict).IsRequired();
    }
}

