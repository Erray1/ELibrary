namespace ELibrary.UserData.DataContext.Entities
{
	public class TakenBook
	{
		public string BookId { get; set; }
		public string LibraryId { get; set; }
		public DateTime RecieveTime { get; set; }
		public DateOnly ReturnDate { get; set; }
	}
}
