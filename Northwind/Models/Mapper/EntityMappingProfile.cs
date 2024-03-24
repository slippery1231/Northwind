using AutoMapper;
using Northwind.Services.Dto;

namespace Northwind.Models.Mapper;

public class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        CreateMap<Customer,CustomerDto>();
    }
}