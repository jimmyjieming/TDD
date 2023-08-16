using Microsoft.AspNetCore.Mvc;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        //private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;
        private readonly IEligibleCheckDemo1 _eligibleCheckDemo1;
        public UsersController(IUsersService usersService, IEligibleCheckDemo1 eligibleCheckDemo1)
        {
            _usersService = usersService;
            _eligibleCheckDemo1 = eligibleCheckDemo1;
            //_logger = logger;
        }

        

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _usersService.GetAllUsers();
            var totalUser = await _eligibleCheckDemo1.CheckUsersLength(6);
            if (users.Any() && totalUser)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}