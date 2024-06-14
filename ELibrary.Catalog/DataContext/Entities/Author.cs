namespace ELibrary.Catalog.DataContext.Entities
{
	public class Author
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<Book> Books { get; set; }
	}
}
