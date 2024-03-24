using Northwind.Services.Dto;

namespace Northwind.Services.Interface;

public interface ICustomerBl
{
    List<CustomerDto> GetCustomerList();
}