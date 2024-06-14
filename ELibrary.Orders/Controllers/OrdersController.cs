using ELibrary.Orders.Application;
using ELibrary.Shared.Dto.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ELibrary.Orders.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class OrdersController : ControllerBase
	{
		private readonly BookingService _bookingService;
        public OrdersController(BookingService booking)
        {
			_bookingService = booking;   
        }
        [HttpPost]
		public async Task<IActionResult> BookABook([FromBody] BookingRequest request)
		{
			var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			var result = await _bookingService.PlaceBooking(request.BookId, request.LibraryId, userId);
			if (!result.IsSuccess)
			{
				return BadRequest(result.Errors);
			}
			return Ok();
		}
	}
}
