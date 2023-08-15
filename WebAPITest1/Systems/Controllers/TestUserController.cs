using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI1.Controllers;
using WebAPI1.Models;
using WebAPITest1.UnitTests.Fixtures;

namespace WebAPITest1.UnitTests.Systems.Controllers
{
    public class TestUserController
    {

        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            //Arrange
            var mockUsersService = new Mock<IUsersService>();
            var mockEligibleCheckDemo1 = new Mock<IEligibleCheckDemo1>();

            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.getTestusers());

            var sut = new UsersController(mockUsersService.Object, mockEligibleCheckDemo1.Object);
            //Act
            var result = (OkObjectResult)await sut.Get();
            //Assert
            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task Get_OnSuccess_invokesUserServiceExactlyOnce()
        {
            //Arrange
            var mockUsersService = new Mock<IUsersService>();
            var mockEligibleCheckDemo1 = new Mock<IEligibleCheckDemo1>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object, mockEligibleCheckDemo1.Object);

            //Act
            var result = await sut.Get();

            //Assert
            mockUsersService.Verify(
                service  => service.GetAllUsers(), 
                Times.Once()
            );
        }
        [Fact]
        public async Task Get_OnSuccess_ReturnsListofUsers()
        {
            //Arrange
            var mockUsersService = new Mock<IUsersService>();
            var mockEligibleCheckDemo1 = new Mock<IEligibleCheckDemo1>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.getTestusers());

            var sut = new UsersController(mockUsersService.Object, mockEligibleCheckDemo1.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }
        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            //Arrange
            var mockUsersService = new Mock<IUsersService>();
            var mockEligibleCheckDemo1 = new Mock<IEligibleCheckDemo1>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object, mockEligibleCheckDemo1.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}