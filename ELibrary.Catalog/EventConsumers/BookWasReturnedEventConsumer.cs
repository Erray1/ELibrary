using ELibrary.Catalog.Application;
using ELibrary.Shared.Contracts;
using MassTransit;

namespace ELibrary.Catalog.EventConsumers
{
	public class BookWasReturnedEventConsumer : IConsumer<BookWasReturnedEvent>
	{
		private readonly BookManager _bookManager;
		private readonly ILogger<BookWasTakenEventConsumer> _logger;
		public BookWasReturnedEventConsumer(
			BookManager bookManager,
			ILogger<BookWasTakenEventConsumer> logger)
		{
			_bookManager = bookManager;
			_logger = logger;
		}
		public async Task Consume(ConsumeContext<BookWasReturnedEvent> context)
		{
			var message = context.Message;
			var result = await _bookManager.MarkBookAs(message.BookId, message.LibraryId, Shared.BookState.Free);
			if (!result.IsSuccess)
			{
				_logger.LogError(String.Join(", ", result.Errors));
			}
		}
	}
}