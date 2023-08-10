using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
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
        _categoryRepository = categoryRepository ?? throw new NullReferenceException(nameof(categoryRepository));
        _mapper = mapper;
    }

    public async Task<CategoryDTO?> Add(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        var createCategory = await _categoryRepository.CreateCategoryAsync(category);

        return _mapper.Map<CategoryDTO>(createCategory);
    }

    public async Task<CategoryDTO?> GetById(int id)
    {
        var takeCategory = await _categoryRepository.GetByIdAsync(id);

        return _mapper.Map<CategoryDTO>(takeCategory);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO?> Remove(int id)
    {
        var category = await _categoryRepository.DeleteCategoryAsync(id);

        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO?> Update(CategoryDTO category)
    {
        var categoryActual = await _categoryRepository.GetByIdAsync(category.Id);
        _mapper.Map(category, categoryActual);

        Category? categoryResponse = null;

        if(categoryActual != null)
        {
            categoryResponse = await _categoryRepository.UpdateCategoryAsync(categoryActual, category.Id);
        }

        return _mapper.Map<CategoryDTO>(categoryResponse);

    }
}