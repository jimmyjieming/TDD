using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI1.Config;
using WebAPI1.Models;
using WebAPI1.Services;
using WebAPITest1.UnitTests.Fakes;

namespace WebAPITest1.UnitTests.Systems.Services
{
    public class TestEligibleCheckServiceDemo1
    {
        [Fact]
        public async Task CheckUsersLength_ReturnsFalse_WhenLessUsersThanValue()
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
            var result = await sut.CheckUsersLength(4);

            //Assert
            result.Should().BeTrue();

        }


        [Fact]
        public async Task CheckUsersLength_ReturnsFalse_WhenLessUsersThanValue_Fabio()
        {
            var fakeUserService = new FakeUsersService();

            var sut = new EligibleCheckServiceDemo1(fakeUserService);

            var result = await sut.CheckUsersLength(4);

            result.Should().BeTrue();
        }
    }
}
