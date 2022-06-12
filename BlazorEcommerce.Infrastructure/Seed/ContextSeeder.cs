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
    private ApplicationContext _context;

    public ContextSeeder(ApplicationContext context)
    {
        _context = context;
    }
    public async Task SeedAsync()
    {
        // File paths go here
        string productFilePath = @"..\SeedingResources\Products.xlsx";
        string userFilePath = @"..\SeedingResources\Users.xlsx";
        string appConfigFilePath = @"..\SeedingResources\ApplicationConfiguration.xlsx";

        // For each entity that needs to be seeded, use the code block below:

        // AppConfig
        if (!_context.ApplicationConfiguration.Any())
        {
            var appConfig = ExcelReader.ReadExcelAndOutputList<ApplicationConfiguration>(appConfigFilePath);
            foreach (var singleAppConfig in appConfig)
            {
                await _context.ApplicationConfiguration.AddAsync((ApplicationConfiguration)singleAppConfig);
            }
            await _context.SaveChangesAsync();
        }


        // Products
        if (!_context.Products.Any())
        {
            var productList = ExcelReader.ReadExcelAndOutputList<Product>(productFilePath);
            foreach (var product in productList)
            {
                await _context.Products.AddAsync((Product)product);
            }
            await _context.SaveChangesAsync();
        }

        // Users
        if (!_context.Users.Any())
        {
            var userList = ExcelReader.ReadExcelAndOutputList<User>(userFilePath);
            foreach (var user in userList)
            {
                await _context.Users.AddAsync((User)user);
            }
            await _context.SaveChangesAsync();
        }
    }
}
