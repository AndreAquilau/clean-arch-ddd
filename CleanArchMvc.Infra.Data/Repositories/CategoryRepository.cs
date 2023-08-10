using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            throw new Exception("Category Not Exists.");
        }

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            throw new Exception("Not Found Category.");
        }

        return category;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var category = await _context.Categories.ToListAsync();

        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        var categoryActualState = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

        if (categoryActualState == null)
        {
            throw new Exception("Not Found Category.");
        }

        _context.Categories.Update(category);

        await _context.SaveChangesAsync();

        return category;
    }
}
