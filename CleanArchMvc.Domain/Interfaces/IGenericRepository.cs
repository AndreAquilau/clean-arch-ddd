using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Domain.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<TEntity> CreateAsync(TEntity obj);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> UpdateAsync(TEntity obj);
    Task<TEntity> RemoveAsync(int id);
}
