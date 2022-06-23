using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.DataAccess.Configurations;
public class UserAuthenticationConfiguration : IEntityTypeConfiguration<UserAuthentication>
{
    public void Configure(EntityTypeBuilder<UserAuthentication> builder)
    {
        builder.Property(ua => ua.Id).HasMaxLength(10);
        builder.Property(ua => ua.UserName).ValueGeneratedNever().HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(ua => ua.Password).ValueGeneratedNever().HasMaxLength(100).IsUnicode(false).IsRequired(false);
        builder.Property(ua => ua.Salt).ValueGeneratedNever().HasMaxLength(100).IsUnicode(false).IsRequired(false);

        builder.HasOne(ua => ua.User).WithOne(u => u.UserAuthentication).HasForeignKey<UserAuthentication>(ua => ua.UserId).OnDelete(DeleteBehavior.Restrict).IsRequired();


    }
}
