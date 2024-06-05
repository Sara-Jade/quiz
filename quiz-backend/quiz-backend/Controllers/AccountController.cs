using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            SignInResult? result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);
            if (!result.Succeeded) { return BadRequest(); }

            IdentityUser? user = await userManager.FindByEmailAsync(credentials.Email);
            return Ok(CreateToken(user));
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            var user = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            IdentityResult userResult = await userManager.CreateAsync(user, credentials.Password);
            if (!userResult.Succeeded) { return BadRequest(userResult.Errors); }

            await signInManager.SignInAsync(user, isPersistent: false);
            return Ok(CreateToken(user));
        }

        private KeyValuePair<string, string> CreateToken(IdentityUser user)
        {
            var claims = new Claim[] { new Claim(JwtRegisteredClaimNames.Sub, user.Id) };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super secret key. Don't use here if this were prod."));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);
            string jwtWritten = new JwtSecurityTokenHandler().WriteToken(jwt);
            var kvp = new KeyValuePair<string, string>("token", jwtWritten);

            return kvp;
        }
    }
}
