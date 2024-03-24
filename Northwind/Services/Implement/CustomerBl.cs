using Northwind.Services.Dto;
using Northwind.Services.Interface;

namespace Northwind.Services.Implement;

public class CustomerBl : ICustomerBl
{
    public List<CustomerDto> GetCustomerList()
    {
        return new List<CustomerDto>
        {
            new()
            {
                CustomerId = "ALFKI",
                CompanyName = "Alfreds Futterkiste",
                ContactName = "Maria Anders",
                ContactTitle = "Sales Representative",
                Address = "Obere Str. 57",
                City = "Berlin",
                PostalCode = "12209",
                Country = "Germany",
                Phone = "030-0074321",
                Fax = "030-0076545"
            }
        };
    }
}