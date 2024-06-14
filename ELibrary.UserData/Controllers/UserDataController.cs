using Ardalis.Result;
using ELibrary.UserData.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ELibrary.UserData.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserDataController : ControllerBase
	{
		private readonly UserDataRepository _dataRepository;
		public UserDataController(UserDataRepository dataRepository) {
			_dataRepository = dataRepository;
		}

		[Authorize(Policy = "User")]
		[HttpGet("my")]
		public async Task<IActionResult> GetUserData()
		{
			var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
			return await getUserData(userId);
		}

		[Authorize(Policy = "Contractor")]
		public async Task<IActionResult> GetUserData(string userId)
		{
			return await getUserData(userId);
		}

		private async Task<IActionResult> getUserData(string userId)
		{
			var result = await _dataRepository.GetAsync(userId);
			if (!result.IsSuccess)
			{
				return NotFound();
			}
			return Ok(result.Value);
		}
	}
}
