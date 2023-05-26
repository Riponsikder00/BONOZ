using BonozApplication.Common.Enum;
using BonozApplication.Managers;
using BonozDomain.AppUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BonozAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersManager _usersManager;

        public UsersController(UsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync(int id) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            (ExecutionState executionState, User user, string message) userObj =  await _usersManager.GetUser(id);
            return Ok(userObj);
        }
    }
}
