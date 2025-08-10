namespace ECommerce_Api.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using ECommerce_Api.Handler;
    using ECommerce_Api.Helpers;
    using ECommerce_Api.Model.Dtos;
    using ECommerce_Api.Model.Entities;
    using ECommerce_Api.Utilities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,

         IOptions<JWT> jwtSettings) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        private readonly JWT _jwtSettings = jwtSettings.Value;

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
                return BadRequest(APIResponse<object>.CreateError(
                                  massage: $"{MassageResponse.FailedRequest}",
                                  error: ressult.Errors
                                  ));
            }

            return Ok(APIResponse<object>.CreateSuccess(new { user.UserName }));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);

            if (!await _userManager.CheckPasswordAsync(user, dto.Password) || user == null)
            {
                return Unauthorized(APIResponse<object>.CreateError(
                    massage: $"{MassageResponse.Unauthorized}",
                    error: new List<IdentityError>()));
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

            return Ok(APIResponse<object>.CreateSuccess(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                ID = user.Id,
                username = user.UserName,
                Role = roles,
                expiration = token.ValidTo
            }));
        }

    }



}
