using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;


        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetCategories()
        {
            try
            {
                var products = await _productService.GetProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.InnerException?.Message });
            }
        }

        [HttpGet(":id")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            try
            {
                var products = await _productService.GetById(id);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
            }
        }

        [HttpPost()]
        public async Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO productDTO)
        {
            try
            {
                var products = await _productService.Add(productDTO);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
            }
        }

        [HttpPut()]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO categoryDTO)
        {
            try
            {
                var category = await _productService.Update(categoryDTO);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
            }
        }

        [HttpDelete(":id")]
        public async Task<ActionResult<ProductDTO>> DeleteById(int id)
        {
            try
            {
                var category = await _productService.Remove(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { Message = ex.InnerException?.Message });
            }
        }

    }
}
