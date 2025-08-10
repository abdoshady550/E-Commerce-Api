using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using TestAPIJWT.Helpers;
using TestAPIJWT.Model.Dtos;
using TestAPIJWT.Model.Entities;

namespace TestAPIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly JWT _jwtSettings;
        public AuthController(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,

             IOptions<JWT> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {

            var user = new AppUser()
            {
                UserName = dto.UserName,
            };
            var ressult = await _userManager.CreateAsync(user, dto.Password);
            if (!ressult.Succeeded)
            {
                return BadRequest(ressult.Errors);
            }
            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(dto.Role));
            }
            await _userManager.AddToRoleAsync(user, dto.Role);


            return Ok(new { user.UserName, Role = dto.Role });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (!await _userManager.CheckPasswordAsync(user, dto.Password) || user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" }); ;
            }
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiresInMin);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                ID = user.Id,
                username = user.UserName,
                Role = roles,
                expiration = token.ValidTo
            });

        }


    }

}
