using ConsoleApp.Ping;

namespace ConsoleApp.Tests.PingTests;

public class NetworkServiceTests
{
    // Naming Convention -> Class_Method_WhatWeWantToHappen
    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        // Arrange -> Variables, Classes, Mocks...
        var pingService = new NetworkService();
        string result;
        
        // Act -> Execute
        result = pingService.SendPing();
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Equal("Success: Ping Sent!", result);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_TotalPingTimout_ReturnInt(int a, int b, int expected)
    {
        // Arrange
        var pingService = new NetworkService();
        int result;
        
        // Act
        result = pingService.TotalPingTimeout(a, b);

        // Assert
        Assert.Equal(expected, result);
        Assert.True( result >= 2 );
        Assert.NotInRange(result, -10000, 0);
    }
}