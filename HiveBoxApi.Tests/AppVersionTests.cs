namespace HiveBoxApi.Tests;
using HiveBoxApi.Services;
using Moq;
public class AppVersionTests
{
    public AppVersionTests()
    {
        
    }
    [Fact]
    public void AppVersionShouldReturnValidValue()
    {
        //this is not testing. testing should mock dependencies but use the 
        //intended service
        //comment
        var mockService = new Mock<IAppVersionService>();

        mockService.Setup(service => service.GetAppVersion()).Returns("v0.0.1");

        var service = mockService.Object;

        string result = service.GetAppVersion();

        Assert.Equal("v0.0.1", result);
    }
}