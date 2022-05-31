using BlazorEcommerce.DataAccess.Seed.Helpers;
using BlazorEcommerce.Infrastructure.Data;
using BlazorEcommerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.DataAccess.Seed;
public class ContextSeeder
{
    private BlazorEcommerceContext _context;

    public ContextSeeder(BlazorEcommerceContext context)
    {
        _context = context;
    }
    public async Task SeedAsync()
    {
        // File paths go here
        string productFilePath = "E:/Projects/CyberMuffin/Repos/BlazorEcommerce/SeedingResources/Products.xlsx";
        string userFilePath = "E:/Projects/CyberMuffin/Repos/BlazorEcommerce/SeedingResources/Users.xlsx";

        // For each entity that needs to be seeded, use the code block below:

        // Products
        if (!_context.Products.Any())
        {
            var productList = ExcelReader.ReadExcelAndOutputList<Product>(productFilePath, typeof(Product).UnderlyingSystemType.FullName);
            foreach (var product in productList)
            {
                await _context.Products.AddAsync((Product)product);
            }
            await _context.SaveChangesAsync();
        }

        // Users
        if (!_context.Users.Any())
        {
            var userList = ExcelReader.ReadExcelAndOutputList<User>(userFilePath, typeof(User).UnderlyingSystemType.FullName);
            foreach (var user in userList)
            {
                await _context.Users.AddAsync((User)user);
            }
            await _context.SaveChangesAsync();
        }
    }
}
