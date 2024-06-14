using ELibrary.UserData.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.UserData.DataContext
{
	public class UserDataDbContext : DbContext
	{
        public UserDataDbContext() { }
		public UserDataDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Entities.UserData> UserData { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Entities.UserData>()
				.HasKey(e => e.UserId);
			builder.Entity<Entities.UserData>()
				.ComplexProperty(e => e.TakenBooks);
			builder.Entity<Entities.UserData>()
				.ComplexProperty(e => e.BookedBooks);
		}
	}
}
