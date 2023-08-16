using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI1.Config;
using WebAPI1.Services;

namespace WebAPITest1.UnitTests.Systems.Services
{
    public class TestEligibleCheckServiceDemo1
    {
        [Theory]
        [InlineData(4)]
        [InlineData(3)]
        public async Task CheckUsersLength_ReturnsFalse_WhenLessUsersThanValue(int value)
        {
            //Arrange
            var httpClientMock = new Mock<HttpClient>();
            var apiConfigMock = new Mock<IOptions<UsersApiOptions>>();
            apiConfigMock.Setup(x => x.Value).Returns(new UsersApiOptions
            {
                Endpoint = "https://jsonplaceholder.typicode.com/users"
            });

            var userServiceMock = new Mock<UsersService>(httpClientMock.Object, apiConfigMock.Object);
            var sut = new EligibleCheckServiceDemo1(userServiceMock.Object);

            //Act
            var result = await sut.CheckUsersLength(value);

            //Assert
            result.Should().BeTrue();

        }
    }
}
