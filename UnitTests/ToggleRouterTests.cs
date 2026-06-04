using Northwind.Controllers;
using Northwind.Services.Interface;
using Northwind.ToggleRouter;
using NSubstitute;
using Xunit;

namespace UnitTests;

public class ToggleRouterTests
{
    [Fact]
    public void Test1()
    {
        var toggleRouter = Substitute.For<IToggleRouter>();
        var customerBl = Substitute.For<ICustomerBl>();

        toggleRouter.IsEnable(ReleaseToggleEnum.VN14).Returns(true);

        var customerController = new CustomerController(customerBl,toggleRouter);

        customerController.GetCustomerList();

        customerBl.Received(1).GetCustomerList();
    }
}