namespace ELibrary.UserData.DataContext.Entities
{
	public class UserData
	{
		public string UserId { get; set; }
		public List<TakenBook> TakenBooks { get; set; } = new List<TakenBook>();
		public List<BookedBook> BookedBooks { get; set; } = new();
	}
}
