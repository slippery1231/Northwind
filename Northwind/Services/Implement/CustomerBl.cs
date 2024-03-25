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
        var customer = _dbRepository.GetEntityById<Customer>(customerViewModel.CustomerId);
        if (customer == null)
        {
            throw new ArgumentException("該客户不存在。", nameof(customerViewModel.CustomerId));
        }
        
        var toBeUpdate = _mapper.Map<Customer>(customerViewModel);
        
        _dbRepository.Update(toBeUpdate);
        
        _dbRepository.Save();
    }

    public CustomerDto GetSingleCustomerInfo(string customerId)
    {
        var customer = _dbRepository.GetEntityById<Customer>(customerId);
        
        if (customer == null)
        {
            throw new ArgumentException("該客户不存在。", nameof(customerId));
        }
        
        return _mapper.Map<CustomerDto>(customer);
    }

    public void AddCustomerInfo(CustomerViewModel viewModel)
    {
        var toBeInsert = _mapper.Map<Customer>(viewModel);
        
        _dbRepository.Create(toBeInsert);
        
        _dbRepository.Save();
    }

    public void DeleteCustomerInfo(string customerId)
    {
        var customer = _dbRepository.GetEntityById<Customer>(customerId);

        if (customer == null)
        {
            throw new ArgumentException("該客户不存在。", nameof(customerId));
        }

        var map = _mapper.Map<Customer>(customer);

        _dbRepository.Delete(map);

        _dbRepository.Save();
    }
}