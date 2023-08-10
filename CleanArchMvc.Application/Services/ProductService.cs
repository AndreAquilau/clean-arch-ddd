using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Repositories;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _mapper= mapper;
        _productRepository= productRepository;
    }

    public async Task<ProductDTO> Add(ProductDTO productDTO)
    {
        var productCreate = _mapper.Map<Product>(productDTO);
        var productCreateResponse = await _productRepository.CreateAsync(productCreate);

        return _mapper.Map<ProductDTO>(productCreateResponse);
    }

    public async Task<ProductDTO?> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await _productRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO?> Remove(int id)
    {
        var product = await _productRepository.RemoveAsync(id);

        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO?> Update(ProductDTO productDTO)
    {
        var productActual = await _productRepository.GetByIdAsync(productDTO.Id);
        _mapper.Map(productDTO, productActual);

        Product? productResponse = null;

        if (productResponse != null)
        {
            productResponse = await _productRepository.UpdateAsync(productActual, productDTO.Id);
        }

        return _mapper.Map<ProductDTO>(productResponse);
    }
}