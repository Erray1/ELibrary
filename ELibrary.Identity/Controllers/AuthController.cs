using ELibrary.Shared.Dto.Requests;
using ELibrary.Shared.Dto.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ELibrary.Identity.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _config;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		public AuthController(
			IConfiguration configuration,
			SignInManager<IdentityUser> signInManager,
			UserManager<IdentityUser> user)
		{
			_config = configuration;
			_signInManager = signInManager;
			_userManager = user;
		}
		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] LoginModel request)
		{
			var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

			if (!result.Succeeded) return BadRequest(new LoginResult { IsSuccessful = false, Error = "Адрес почты или пароль неверны" });

			var claims = new[]
			{
			new Claim(ClaimTypes.Email, request.Email)
		};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSecurityKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expiry = DateTime.Now.AddDays(Convert.ToInt32(_config["JWTExpiryInDays"]));

			var token = new JwtSecurityToken(
				_config["JWTIssuer"],
				_config["JWTAudience"],
				claims,
				expires: expiry,
				signingCredentials: creds);
			return Ok(new LoginResult { IsSuccessful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] RegisterModel model)
		{
			IdentityUser newUser = new() { UserName = model.Name, Email = model.Email};

			var result = await _userManager.CreateAsync(newUser, model.Password!);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(x => x.Description);

				return Ok(new RegisterResult { IsSuccessful = false, Error = "неудача....." });
			}
			else return Ok(new RegisterResult { IsSuccessful = true });
		}
	}
}
