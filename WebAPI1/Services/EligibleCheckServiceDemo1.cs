using WebAPI1.Models;

namespace WebAPI1.Services
{
    public class EligibleCheckServiceDemo1: IEligibleCheckDemo1
    {
        private readonly IUsersService _usersService;
        public EligibleCheckServiceDemo1(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<bool> CheckUsersLength(int value) {
            var users = await _usersService.GetAllUsers();
            var filteredUsers = users.Where(user => user.Id > 5).ToList();
            var total = filteredUsers.Count() - value;
            return total > 0;
        }
    }
}
