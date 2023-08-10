using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> RemoveAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return product;

    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        return product;
    }

    public async Task<Product> GetProducCategoreAsync(int id)
    {

        var products = await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);

        if (products == null)
        {
            throw new NullReferenceException(nameof(products));
        }

        return products;

    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _context.Products.ToArrayAsync();

        return products;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        var dataProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

        if (dataProduct == null)
        {
            throw new NullReferenceException(nameof(dataProduct));
        }

        _context.Products.Update(product);

        await _context.SaveChangesAsync();

        return product;
    }
}
