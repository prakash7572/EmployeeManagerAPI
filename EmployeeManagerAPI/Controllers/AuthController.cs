using EmployeeManagerAPI.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IConfiguration _config;
        readonly IUser _user;
        public AuthController(IUser user, IConfiguration config)
        {
            this._user = user;
            this._config = config;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Model.User user)
        {
            return Ok(await _user.Register(user));
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Model.UserLogin user)
        {
            try
            {
                var validateUser = await _user.Login(user);

                if (validateUser == null)
                    return NotFound("User not found");

                var claims = new[]
                {
                     new Claim(ClaimTypes.Name, validateUser.Username ?? string.Empty),
                     new Claim(ClaimTypes.Role, validateUser.Role ?? string.Empty),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    message = "Login successfully!",
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Technical Error!!");
            }
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var username = User.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                    return Unauthorized();

                var user = await _user.CurrentUserInfo(username);
                if (user == null)
                    return NotFound();

                return Ok(new
                {
                    user.Username,
                    user.Email,
                    user.FullName,
                    user.Created
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Technical Error!!");
            }
            
        }


    }

}
