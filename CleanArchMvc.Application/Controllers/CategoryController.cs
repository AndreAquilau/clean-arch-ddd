using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;


    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
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
            return BadRequest(new { Message = ex.InnerException?.Message });
        }
    }

    [HttpGet(":id")]
    public async Task<ActionResult<CategoryDTO>> GetById(int id)
    {
        try
        {
            var category = await _categoryService.GetById(id);

            return Ok(category);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
        }
    }

    [HttpPost()]
    public async Task<ActionResult<CategoryDTO>> Create([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            var category = await _categoryService.Add(categoryDTO);

            return Ok(category);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
        }
    }

    [HttpPut()]
    public async Task<ActionResult<CategoryDTO>> Update([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            var category = await _categoryService.Update(categoryDTO);

            return Ok(category);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
        }
    }

    [HttpDelete(":id")]
    public async Task<ActionResult<CategoryDTO>> DeleteById(int id)
    {
        try
        {
            var category = await _categoryService.Remove(id);

            return Ok(category);
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
        }
    }


}
