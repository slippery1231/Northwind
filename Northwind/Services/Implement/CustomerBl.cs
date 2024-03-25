using AutoMapper;
using Northwind.Models.Dto;
using Northwind.Models.Entities;
using Northwind.Models.ViewModel;
using Northwind.Repositories.Implement;
using Northwind.Services.Interface;

namespace Northwind.Services.Implement;

public class CustomerBl : ICustomerBl
{
    private readonly DbRepository _dbRepository;
    private readonly IMapper _mapper;

    public CustomerBl(DbRepository dBRepository, IMapper mapper)
    {
        _dbRepository = dBRepository;
        _mapper = mapper;
    }

    public IEnumerable<CustomerDto> GetCustomerList()
    {
        var data = _dbRepository.GetAll<Customer>();
        return _mapper.Map<IEnumerable<CustomerDto>>(data).ToList();
    }

    public void UpdateCustomerInfo(CustomerViewModel customerViewModel)
    {
        var toBeUpdate = _mapper.Map<Customer>(customerViewModel);
        _dbRepository.Update(toBeUpdate);
        _dbRepository.Save();
    }

    public CustomerDto GetSingleCustomerInfo(string customerId)
    {
        var data = _dbRepository.GetEntityById<Customer>(customerId);
        return _mapper.Map<CustomerDto>(data);
    }
}