using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings;

public class ProfileConfiguration : Profile
{
    public ProfileConfiguration()
    {
        base.CreateMap<ProductDTO, Product>().ReverseMap();
        base.CreateMap<CategoryDTO, Category>().ReverseMap();
    }
}