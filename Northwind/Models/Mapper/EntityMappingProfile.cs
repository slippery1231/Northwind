using AutoMapper;
using Northwind.Models.Dto;
using Northwind.Models.Entities;
using Northwind.Models.ViewModel;

namespace Northwind.Models.Mapper;

public class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        CreateMap<Customer,CustomerDto>();
        CreateMap<CustomerViewModel,Customer>();
    }
}