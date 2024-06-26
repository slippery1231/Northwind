using Northwind.Models.Dto;
using Northwind.Models.ViewModel;

namespace Northwind.Services.Interface;

public interface ICustomerBl
{
    IEnumerable<CustomerDto> GetCustomerList();
    
    IEnumerable<CustomerDto> GetCustomerList2();
    
    void UpdateCustomerInfo(CustomerViewModel customerViewModel);

    CustomerDto GetSingleCustomerInfo(string customerId);

    void AddCustomerInfo(CustomerViewModel viewModel);

    void DeleteCustomerInfo(string customerId);
}