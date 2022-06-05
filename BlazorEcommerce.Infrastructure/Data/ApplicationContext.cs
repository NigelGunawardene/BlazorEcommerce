using BlazorEcommerce.DataAccess.Seed.Helpers;
using BlazorEcommerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Infrastructure.Data;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<ApplicationConfiguration> ApplicationConfiguration { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;




    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Add Products here
    //    modelBuilder.Entity<Product>().HasData(ExcelReader.ReadExcelAndOutputList<Product>("filePath", typeof(Product).UnderlyingSystemType.FullName));
    //}
}

