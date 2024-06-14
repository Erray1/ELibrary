using ELibrary.Shared.Dto;

namespace ELibrary.Catalog.DataContext.Entities
{
	public static class Mapping
	{
		public static BookFullDto ToDto(this Book book)
		{
			var libraries = book.LibraryBooks
				.Where(x => !x.IsTaken)
				.Select(x => new LibraryNestedDto
				{
					Address = x.Library.Address,
					LibraryName = x.Library.Name,
				})
				.ToList();
			return new BookFullDto()
			{
				BookId = book.Id,
				Description = book.Description,
				BookName = book.Name,
				CategoryName = book.Categories
					.Select(x => x.Name)
					.ToList(),
				ImageName = book.Id,
				YearWritten = book.YearWritten,
				Authors = book.Authors
					.Select(x => x.Name)
					.ToList(),
				AvailableInLibraries = libraries
			};
		}

		public static BookShortDto ToShortDto(this Book book)
		{
			return new BookShortDto()
			{
				BookId = book.Id,
				Description = book.Description,
				BookName = book.Name,
				CategoryName = book.Categories
					.Select(x => x.Name)
					.ToList(),
				ImageName = book.Id,
				YearWritten = book.YearWritten,
				Authors = book.Authors
					.Select(x => x.Name)
					.ToList(),
			};
		}
	}
}
