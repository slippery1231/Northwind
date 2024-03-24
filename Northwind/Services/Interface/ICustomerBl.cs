using Northwind.Services.Dto;

namespace Northwind.Services.Interface;

public interface ICustomerBl
{
    IEnumerable<CustomerDto> GetCustomerList();
}