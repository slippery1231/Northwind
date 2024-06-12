using AutoMapper;
using Northwind.ExceptionHandler;
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
    
    //假設toggle off =>要走舊的
    public IEnumerable<CustomerDto> GetCustomerList2()
    {
        var data = _dbRepository.GetAll<Customer>();

        return _mapper.Map<IEnumerable<CustomerDto>>(data).ToList();
    }

    public void UpdateCustomerInfo(CustomerViewModel customerViewModel)
    {
        var customer = _dbRepository.GetEntityById<Customer>(customerViewModel.CustomerId,true);

        if (customer == null)
        {
            throw new CustomerNotFoundException("Customer is not found");
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
            throw new CustomerNotFoundException("Customer is not found");
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
            throw new CustomerNotFoundException("Customer is not found");
        }

        var map = _mapper.Map<Customer>(customer);

        _dbRepository.Delete(map);

        _dbRepository.Save();
    }
}