using Ardalis.Result;
using ELibrary.Catalog.Infrastructure;
using ELibrary.Shared;

namespace ELibrary.Catalog.Application
{
	public class BookManager
	{
		private readonly CatalogDbContext _dbContext;
        public BookManager(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result> AddBook()
		{
			throw new NotImplementedException();
		}
		public async Task<Result> MarkBookAs(string bookId, string libraryId, BookState bookState)
		{
			var library = _dbContext.Libraries
				.SingleOrDefault(x => x.Id == libraryId);
			if (library is null)
			{
				return Result.NotFound($"Не найдено библиотеки с id {libraryId}");
			}
			var libraryBook = library.LibraryBooks
				.SingleOrDefault(x => x.BookId == bookId);
			if (libraryBook is null )
			{
				return Result.NotFound($"В библиотеке {libraryId} не найдено книги с id {bookId}");
			}
			if (libraryBook.BookState == bookState)
			{
				return Result.Error($"Библиотека {libraryId} книга {bookId} уже имеет статус {bookState}");
			}
			libraryBook.BookState = bookState;
			await _dbContext.SaveChangesAsync();
			return Result.Success();
		}
		public async Task<Result> AddLibrary()
		{
			throw new NotImplementedException();
		}
	}
}
