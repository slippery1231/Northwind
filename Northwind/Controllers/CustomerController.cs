using Microsoft.AspNetCore.Mvc;
using Northwind.Models.ViewModel;
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
    [HttpGet("api/customer/GetSingleCustomerInfo")]
    public IActionResult GetSingleCustomerInfo(string customerId)
    {
        var customer = _customerBl.GetSingleCustomerInfo(customerId);
        return Ok(customer);
    }

    [HttpPut("api/customer/UpdateCustomerInfo")]
    public IActionResult UpdateCustomerInfo([FromBody] CustomerViewModel viewModel)
    {
        _customerBl.UpdateCustomerInfo(viewModel);
        return Ok();
    }
}