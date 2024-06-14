namespace ELibrary.Catalog.DataContext.Entities
{
	public class Book
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int YearWritten { get; set; }
		public List<Category> Categories { get; set; } = new();
		public List<Library> Librarys { get; set; } = new();
		public List<LibraryBook> LibraryBooks { get; set; } = new();		
		public List<Author> Authors { get; set; } = new();
	}
}
