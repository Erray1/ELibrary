using ELibrary.Shared;

namespace ELibrary.Catalog.DataContext.Entities
{
	public class LibraryBook
	{
		public string BookId { get; set; }
		public string LibraryId { get; set; }
		public Book Book { get; set; }
		public Library Library { get; set; }
		public BookState BookState { get; set; }
		public bool IsTaken => BookState != BookState.Free;
	}
}
