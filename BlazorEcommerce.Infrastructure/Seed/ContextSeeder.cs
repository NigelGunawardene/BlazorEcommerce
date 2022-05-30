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
        if (!_context.Products.Any())
        {
            var genericList = ExcelReader.ReadExcelAndOutputList<Product>("E:/Projects/CyberMuffin/Repos/BlazorEcommerce/SeedingResources/Products.xlsx", typeof(Product).UnderlyingSystemType.FullName);
            var productList = new List<Product>();
            foreach (var product in genericList)
            {
                productList.Add(new Product
                {
                    Title = product.ToString()
                });
            }

            foreach (var product in productList)
            {
                _context.Products.Add(product);
            }

        }
    }
}
