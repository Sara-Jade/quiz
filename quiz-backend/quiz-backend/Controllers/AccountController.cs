using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quiz_backend.Controllers
{
    public struct Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly UserManager<IdentityUser> userManager;
        readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
        { 
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            var user = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var userResult = await userManager.CreateAsync(user, credentials.Password);

            if (!userResult.Succeeded) { return BadRequest(userResult.Errors); }
            await signInManager.SignInAsync(user, isPersistent: false);

            var jwt = new JwtSecurityToken();
            string jwtWritten = new JwtSecurityTokenHandler().WriteToken(jwt);
            var kvp = new KeyValuePair<string, string>("token", jwtWritten);

            return Ok(kvp);
        }
    }
}
