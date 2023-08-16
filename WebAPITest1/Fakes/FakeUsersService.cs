using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPITest1.UnitTests.Fakes
{
    class FakeUsersService : IUsersService
    {
        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(
                new List<User>()
                {
                    new() {
                        Id = 1,
                        Address = new()
                        {
                            City = "fake city",
                            Street = "fake st",
                            Zipcode = "12345",
                        },
                        Email = "hello@test.com",
                        Name = "Tester",
                    },
                    new() {
                        Id = 10,
                        Address = new()
                        {
                            City = "fake city",
                            Street = "fake st",
                            Zipcode = "12345",
                        },
                        Email = "hello@test.com",
                        Name = "Tester",
                    },
                    new() {
                        Id = 11,
                        Address = new()
                        {
                            City = "fake city",
                            Street = "fake st",
                            Zipcode = "12345",
                        },
                        Email = "hello@test.com",
                        Name = "Tester",
                    },
                    new() {
                        Id = 12,
                        Address = new()
                        {
                            City = "fake city",
                            Street = "fake st",
                            Zipcode = "12345",
                        },
                        Email = "hello@test.com",
                        Name = "Tester",
                    },
                    new() {
                        Id = 13,
                        Address = new()
                        {
                            City = "fake city",
                            Street = "fake st",
                            Zipcode = "12345",
                        },
                        Email = "hello@test.com",
                        Name = "Tester",
                    },
                    new() {
                        Id = 14,
                        Address = new()
                        {
                            City = "fake city",
                            Street = "fake st",
                            Zipcode = "12345",
                        },
                        Email = "hello@test.com",
                        Name = "Tester",
                    },
                });
        }
    }
}
