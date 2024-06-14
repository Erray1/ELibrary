using ELibrary.Catalog.Application;
using ELibrary.Shared;
using ELibrary.Shared.Contracts;
using MassTransit;

namespace ELibrary.Catalog.EventConsumers
{
	public class BookWasTakenEventConsumer : IConsumer<BookWasTakenEvent>
	{
		private readonly BookManager _bookManager;
		private readonly ILogger<BookWasTakenEventConsumer> _logger;
        public BookWasTakenEventConsumer(
			BookManager bookManager,
			ILogger<BookWasTakenEventConsumer> logger)
        {
			_bookManager = bookManager;
			_logger = logger;
        }
        public async Task Consume(ConsumeContext<BookWasTakenEvent> context)
		{
			var message = context.Message;
			var result = await _bookManager.MarkBookAs(message.BookId, message.LibraryId, BookState.Taken);
			if (!result.IsSuccess)
			{
				_logger.LogError(String.Join(", ", result.Errors));
			}
		}
	}
}
