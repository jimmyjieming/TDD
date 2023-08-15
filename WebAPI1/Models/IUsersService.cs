namespace WebAPI1.Models
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }
}
