using ELibrary.Catalog.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Catalog.Infrastructure
{
	public class CatalogDbContext : DbContext
	{
        public CatalogDbContext() { }
        public CatalogDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
		public DbSet<Library> Libraries { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
		}
	}
}
