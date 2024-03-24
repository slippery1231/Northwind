using Microsoft.AspNetCore.Mvc;
using Northwind.Services.Implement;

namespace Northwind.Controllers;

public class CustomerController : Controller
{
    [HttpGet("api/customer/GetCustomerList")]
    public IActionResult GetCustomerList()
    {
        var customerBl = new CustomerBl();
        var customerList = customerBl.GetCustomerList();
        return Ok(customerList);
    }
}