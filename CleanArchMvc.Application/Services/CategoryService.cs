using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    Task ICategoryService.Add(CategoryDTO category)
    {
        throw new NotImplementedException();
    }

    Task<CategoryDTO> ICategoryService.GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        var categoriesDTO = categories.Select(obj => _mapper.Map<CategoryDTO>(obj));

        return categoriesDTO;
    }

    Task ICategoryService.Remove(int id)
    {
        throw new NotImplementedException();
    }

    Task ICategoryService.Update(CategoryDTO category)
    {
        throw new NotImplementedException();
    }
}