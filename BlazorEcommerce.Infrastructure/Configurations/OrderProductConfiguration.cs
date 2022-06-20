using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEcommerce.DataAccess.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.Property(op => op.OrderId).HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(op => op.ProductId).HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(op => op.Quantity).ValueGeneratedNever().HasMaxLength(6).IsUnicode(false).IsRequired();
        builder.Property(op => op.Price).ValueGeneratedNever().HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(op => op.TotalPrice).ValueGeneratedNever().HasMaxLength(20).IsUnicode(false).IsRequired();

        builder.HasOne(op => op.Order).WithMany(o => o.OrderProducts).HasForeignKey(op => op.OrderId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        builder.HasOne(op => op.Product).WithMany(p => p.OrderProducts).HasForeignKey(op => op.ProductId).OnDelete(DeleteBehavior.Restrict).IsRequired();
    }
}

