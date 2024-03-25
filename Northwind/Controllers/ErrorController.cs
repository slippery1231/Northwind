using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models.ViewModel;

namespace Northwind.Controllers;

[ApiController]
public class ErrorController : Controller
{
    [Route("api/error")]
    public ActionResult<ErrorResponseVm> Error()
    {
        var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();
        if (ex != null)
        {
            return StatusCode(
                (int)HttpStatusCode.InternalServerError,
                new ErrorResponseVm
                {
                    ErrorNo = DateTime.UtcNow.ToString("yyyyMMddHHss"),
                    ErrorMessage = ex.Error.Message
                });
        }

        return StatusCode(
            (int)HttpStatusCode.InternalServerError,
            new ErrorResponseVm
            {
                ErrorNo = DateTime.UtcNow.ToString(CultureInfo.CurrentCulture),
                ErrorMessage = "ERROR OCCURRED!"
            });
    }
}