using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEcommerce.DataAccess.Configurations;

public class ApplicationConfigurationConfiguration : IEntityTypeConfiguration<ApplicationConfiguration>
{
    public void Configure(EntityTypeBuilder<ApplicationConfiguration> builder)
    {
        builder.Property(ac => ac.Id).HasMaxLength(10);
        builder.Property(ac => ac.WelcomeMessage).ValueGeneratedNever().HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(ac => ac.PrimaryColor).ValueGeneratedNever().HasMaxLength(10).IsUnicode(false).IsRequired();
        builder.Property(ac => ac.SecondaryColor).ValueGeneratedNever().HasMaxLength(10).IsUnicode(false).IsRequired();
        builder.Property(ac => ac.AppName).ValueGeneratedNever().HasMaxLength(50).IsUnicode(false).IsRequired();
    }
}

