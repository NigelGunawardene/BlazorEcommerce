﻿using BlazorEcommerce.DataAccess.Seed.Helpers;
using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Infrastructure.Data;
public class BlazorEcommerceContext : DbContext
{
    public BlazorEcommerceContext(DbContextOptions<BlazorEcommerceContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Add Products here
    //    modelBuilder.Entity<Product>().HasData(ExcelReader.ReadExcelAndOutputList<Product>("filePath", typeof(Product).UnderlyingSystemType.FullName));
    //}
}

