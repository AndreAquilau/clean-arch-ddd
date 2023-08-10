using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO?> GetById(int id);
    Task<CategoryDTO?> Add(CategoryDTO category);
    Task<CategoryDTO?> Update(CategoryDTO category);
    Task<CategoryDTO?> Remove(int id);

}
