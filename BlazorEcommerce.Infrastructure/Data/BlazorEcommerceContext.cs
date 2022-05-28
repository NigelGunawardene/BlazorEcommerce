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

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add Products here
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "prod3",
                Description = "proddesc1",
                ImageUrl = "https://nerdist.com/wp-content/uploads/2021/04/Aliens-xenomorph.jpg",
                Price = 100
            },
            new Product
            {
                Id = 2,
                Title = "prod2",
                Description = "proddesc1",
                ImageUrl = "https://nerdist.com/wp-content/uploads/2021/04/Aliens-xenomorph.jpg",
                Price = 100
            }
        );
    }
}

