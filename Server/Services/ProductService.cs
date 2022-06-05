﻿using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services;

public class ProductService : IProductService
{
    private readonly ApplicationContext _context;

    public ProductService(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Message = "All Products",
            Success = true,
            Data = await _context.Products.ToListAsync()
        };

        response.Data.ForEach(item => item.ImageUrl = @"./images/dota.jpg");
        return response;
    }
}
