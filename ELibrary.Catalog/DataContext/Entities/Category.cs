namespace ELibrary.Catalog.DataContext.Entities
{
	public class Category
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<Book> Books { get; set; } = new();
	}
}
