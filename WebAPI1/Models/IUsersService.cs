namespace WebAPI1.Models
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }

    public interface IEligibleCheckDemo1
    {
        public Task<bool> CheckUsersLength(int value);
    }
}
