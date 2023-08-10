using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO?> GetById(int id);
    Task<ProductDTO> Add(ProductDTO productDTO);
    Task<ProductDTO?> Update(ProductDTO productDTO, int id);
    Task<ProductDTO?> Remove(int id);
}