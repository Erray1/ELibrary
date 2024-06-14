using ELibrary.Catalog.DataContext.Entities;

namespace ELibrary.Catalog.DataContext.Domain
{
	public class SearchTerms
	{
		public static SearchTerms FromRequestQuery(IQueryCollection httpQuery)
		{
			return new();
		}

		public List<Func<Book, bool>>? SearchRules { get; set; } = new();
	}
}
