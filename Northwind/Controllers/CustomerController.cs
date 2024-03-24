using Microsoft.AspNetCore.Mvc;
using Northwind.Services.Implement;
using Northwind.Services.Interface;

namespace Northwind.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerBl _customerBl;
    public CustomerController(ICustomerBl customerBl)
    {
        _customerBl = customerBl;
    }
    [HttpGet("api/customer/GetCustomerList")]
    public IActionResult GetCustomerList()
    {
        var customerList = _customerBl.GetCustomerList();
        return Ok(customerList);
    }
}