using Moq;
using FluentAssertions;
using Microsoft.Extensions.Options;
using WebAPI1.Config;
using WebAPITest1.UnitTests.Fixtures;
using WebAPI1.Models;

namespace WebAPITest1.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers()
        {
            // Arrange
            var expectedResponse = UsersFixture.getTestusers();

            var httpClientMock = new Mock<HttpClient>();
            var apiConfigMock = new Mock<IOptions<UsersApiOptions>>();
            apiConfigMock.Setup(x => x.Value).Returns(new UsersApiOptions
            {
                Endpoint = "https://jsonplaceholder.typicode.com/users"
            });

            var sut = new UsersService(httpClientMock.Object, apiConfigMock.Object);

            // Act
            var result = await sut.GetAllUsers();

            // Assert
            result.Should().BeOfType<List<User>>();
        }
    }
}
