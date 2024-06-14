namespace ELibrary.UserData.DataContext.Entities
{
	public class BookedBook
	{
		public string BookId { get; set; }
		public string LibraryId { get; set; }
		public DateTime BookingCreatedAtTime { get; set; }
		public DateTime ExpirationTime { get; set; }
	}
}
