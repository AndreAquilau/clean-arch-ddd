using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Application.Controllers;

[ApiController]
[Route("[controller]/api")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;


    public CategoryController(ILogger<CategoryController> logger,ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet(Name = "v1/Categories")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetCategories();

            return Ok(categories);
        }
        catch (Exception ex) 
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
