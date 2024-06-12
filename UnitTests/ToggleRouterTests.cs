using AutoMapper;
using Northwind.Controllers;
using Northwind.Services.Interface;
using Northwind.ToggleRouter;
using NSubstitute;

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

        var getCustomerList = customerController.GetCustomerList();

        customerBl.Received(1).GetCustomerList2();
    }
}