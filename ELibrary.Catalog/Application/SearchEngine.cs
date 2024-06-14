using ELibrary.Catalog.DataContext.Domain;
using ELibrary.Catalog.DataContext.Entities;
using ELibrary.Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ELibrary.Catalog.Application
{
	public class SearchEngine
	{
		private readonly CatalogDbContext _dbContext;
        public SearchEngine(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Book>> SearchAsync(SearchTerms searchTerms)
		{
			var searchExpression = getSearchExpression(searchTerms);
			return await _dbContext.Books
				.Where(searchExpression)
				.ToListAsync();
		}
		private Expression<Func<Book, bool>> getSearchExpression(SearchTerms searchTerms)
		{

		}
	}
}
