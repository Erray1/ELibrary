using ELibrary.Catalog.Application;
using ELibrary.Shared;
using ELibrary.Shared.Contracts;
using MassTransit;

namespace ELibrary.Catalog.EventConsumers
{
	public class BookWasBookedEventConsumer : IConsumer<BookWasBookedEvent>
	{
		private readonly BookManager _bookManager;
		private readonly ILogger<BookWasBookedEventConsumer> _logger;
		public BookWasBookedEventConsumer(
			BookManager bookManager,
			ILogger<BookWasBookedEventConsumer> logger)
		{
			_bookManager = bookManager;
			_logger = logger;
		}
		public async Task Consume(ConsumeContext<BookWasBookedEvent> context)
		{
			var message = context.Message;
			var result = await _bookManager.MarkBookAs(message.BookId, message.LibraryId, BookState.Booked);
			if (!result.IsSuccess)
			{
				_logger.LogError(String.Join(", ", result.Errors));
			}
		}
	}
}

