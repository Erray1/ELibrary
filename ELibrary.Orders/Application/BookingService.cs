using Ardalis.Result;
using ELibrary.Shared.Contracts;
using MassTransit;

namespace ELibrary.Orders.Application
{
	public class BookingService
	{
		private readonly int i = 0;
		private readonly IConfiguration _config;
		private readonly IPublishEndpoint _endpoint;
		public BookingService(
			IConfiguration config,
			IPublishEndpoint publish)
		{
			_config = config;
			_endpoint = publish;
		}
		public async Task<Result> PlaceBooking(string bookId, string libraryId, string userId)
		{
			var bookingDuration = Convert.ToInt32(_config.GetSection("BookingDurationDays"));
			var creationDate = DateTime.Now;
			var expirationDate = creationDate.AddDays(bookingDuration);
			BookWasBookedEvent bookWasBookedEvent = new(bookId, libraryId, userId, creationDate, expirationDate);

			await _endpoint.Publish(bookWasBookedEvent);

			return Result.Success();
		}
	}
}

