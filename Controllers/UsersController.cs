using ApexTravels.ResourceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApexTravels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        /*
         * Controller defines a dependency on UserManager<IdentityUser>,
         * with the instance being injected in the constructor  
         */
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager) 
        {
            _userManager = userManager;
        }

        // Create a new user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
             * Extract the parameters obtained from the request and 
             * use them to create a user.
             */

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = user.UserName, Email = user.EmailAddress, },
                user.Password);

            if (!result.Succeeded) 
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            return CreatedAtAction("GetUser", new { username = user.UserName }, user);
        }

        // Get a user
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            IdentityUser user = await _userManager.FindByNameAsync(username);
            if (user == null) 
            {
                return NotFound();
            }

            return new User { UserName = user.UserName, EmailAddress = user.Email };
        }
        
    }
}
