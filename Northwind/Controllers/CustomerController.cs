using Microsoft.AspNetCore.Mvc;
using Northwind.Models.ViewModel;
using Northwind.Services.Interface;
using Northwind.ToggleRouter;

namespace Northwind.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerBl _customerBl;
    private readonly IToggleRouter _toggleRouter;

    public CustomerController(ICustomerBl customerBl, IToggleRouter toggleRouter)
    {
        _customerBl = customerBl;
        _toggleRouter = toggleRouter;
    }

    /// <summary>
    /// 取得客戶清單
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/customer/GetCustomerList")]
    public IActionResult GetCustomerList()
    {
        var isEnable = _toggleRouter.IsEnable(ReleaseToggleEnum.VN14);

        if (isEnable)
        {
            var customerList = _customerBl.GetCustomerList();
            return Ok(customerList);
        }
        else
        {
            var customerList = _customerBl.GetCustomerList2();
            return Ok(customerList);
        }
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
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new { Message = "資料未填寫完整", Errors = errors });
        }

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
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest(new { Message = "未傳入客戶代碼" });
        }

        _customerBl.DeleteCustomerInfo(customerId);
        return Ok();
    }
}