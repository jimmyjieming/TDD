using WebAPI1.Models;

namespace WebAPITest1.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> getTestusers() => new()
        {
            new User
            {
                Name = "Test",
                Email = "test@test.com",
                Address = new Address
                {
                    Street = "TEST1",
                    City = "Canberra",
                    Zipcode = "2601",
                }
            },
            new User
            {
                Name = "Test2",
                Email = "test2@test.com",
                Address = new Address
                {
                    Street = "TEST2",
                    City = "Canberra",
                    Zipcode = "2601",
                }
            },
            new User
            {
                Name = "Test3",
                Email = "test3@test.com",
                Address = new Address
                {
                    Street = "TEST3",
                    City = "Canberra",
                    Zipcode = "2601",
                }
            },
        };
    }
}
