using Ardalis.Result;
using ELibrary.Catalog.DataContext.Entities;
using ELibrary.Catalog.Infrastructure;
using ELibrary.Shared;

namespace ELibrary.Catalog.Application
{
	public class BookRepository
	{
		private readonly CatalogDbContext _dbContext;
        public BookRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Book>> GetByIdAsync(string bookId)
		{
			var book = await _dbContext.Books.FindAsync(bookId);
			if (book is null)
			{
				return Result.NotFound($"Книги с id {bookId} не найдено");
			}
			return Result.Success(book);
		}

		public async Task<Result<BookState>> GetBookStateForLibraryAsync(string bookId, string libraryId)
		{
			var bookResult = await GetByIdAsync(bookId);
            if (!bookResult.IsSuccess)
            {
				return Result.NotFound(String.Join(", ", bookResult.Errors));
            }
			var book = bookResult.Value;
			var bookLibrary = book.LibraryBooks.SingleOrDefault(x => x.LibraryId == libraryId);
			if (bookLibrary is null)
			{
				return Result.NotFound($"Не найдено библиотеки с id {libraryId}");
			}
			return bookLibrary.BookState;
        }
	}
}
