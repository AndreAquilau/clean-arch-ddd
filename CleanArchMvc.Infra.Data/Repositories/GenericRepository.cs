using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
{
    private ApplicationDbContext _context { get; set; }

    public GenericRepository( ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> CreateAsync(TEntity obj)
    {
        if(obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        await _context.Set<TEntity>().AddAsync(obj);
    
        await _context.SaveChangesAsync();

        return obj;

    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var dataAll = await _context.Set<TEntity>().ToArrayAsync<TEntity>();

        return dataAll;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var dataById = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        if(dataById == null)
        {
            throw new NullReferenceException(nameof(dataById));
        }

        return dataById;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj)
    {

        var dataById = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == obj.Id);

        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        _context.Set<TEntity>().Update(obj);

        await _context.SaveChangesAsync();

        return obj;

    }

    public async Task<TEntity> RemoveAsync(int id)
    {
        var dataById = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        if (dataById == null)
        {
            throw new ArgumentNullException(nameof(dataById));
        }

        _context.Remove(dataById);

        await _context.SaveChangesAsync();

        return dataById;
    }

}

