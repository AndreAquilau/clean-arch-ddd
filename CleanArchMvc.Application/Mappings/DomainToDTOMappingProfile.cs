using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        base.CreateMap<ProductDTO, Product>().ReverseMap();
        base.CreateMap<CategoryDTO, Category>().ReverseMap();
    }
}