namespace ELibrary.Catalog.DataContext.Entities
{
	public class Library
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public List<Book> Books { get; set; } = new();
		public List<LibraryBook> LibraryBooks { get; set; } = new();
	}
}
