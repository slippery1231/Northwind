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

    /// <summary>
    /// 取得客戶清單
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/customer/GetCustomerList")]
    public IActionResult GetCustomerList()
    {
        var customerList = _customerBl.GetCustomerList();
        return Ok(customerList);
    }

    /// <summary>
    /// 取得單一客戶資料
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("api/customer/GetSingleCustomerInfo")]
    public IActionResult GetSingleCustomerInfo(string customerId)
    {
        var customer = _customerBl.GetSingleCustomerInfo(customerId);
        return Ok(customer);
    }

    /// <summary>
    /// 更新單一筆客戶資料
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPut("api/customer/UpdateCustomerInfo")]
    public IActionResult UpdateCustomerInfo([FromBody] CustomerViewModel viewModel)
    {
        _customerBl.UpdateCustomerInfo(viewModel);
        return Ok();
    }

    /// <summary>
    /// 新增一筆客戶資料
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPost("api/customer/AddCustomerInfo")]
    public IActionResult AddCustomerInfo([FromBody] CustomerViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new { Message = "資料未填寫完整", Errors = errors });
        }

        _customerBl.AddCustomerInfo(viewModel);
        return Ok();
    }

    /// <summary>
    /// 刪除單筆客戶資料
    /// </summary>
    /// <returns></returns>
    [HttpDelete("api/customer/DeleteCustomerInfo")]
    public IActionResult DeleteCustomerInfo(string customerId)
    {
        _customerBl.DeleteCustomerInfo(customerId);
        return Ok();
    }
}