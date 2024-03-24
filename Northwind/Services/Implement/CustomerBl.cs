using AutoMapper;
using Northwind.Models;
using Northwind.Models.Dto;
using Northwind.Repositories.Implement;
using Northwind.Services.Interface;

namespace Northwind.Services.Implement;

public class CustomerBl : ICustomerBl
{
    private readonly DbRepository _dbRepository;
    private readonly IMapper _mapper;
    public CustomerBl(DbRepository dBRepository,IMapper mapper)
    {
        _dbRepository = dBRepository;
        _mapper = mapper;
    }
    public IEnumerable<CustomerDto> GetCustomerList()
    {
        var data=_dbRepository.GetAll<Customer>();
        return _mapper.Map<IEnumerable<CustomerDto>>(data).ToList();
    }
}