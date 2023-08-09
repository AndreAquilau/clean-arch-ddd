using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Application.Controllers;

[ApiController]
[Route("[controller]/api")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;



    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "v1/Categories")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex) 
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
