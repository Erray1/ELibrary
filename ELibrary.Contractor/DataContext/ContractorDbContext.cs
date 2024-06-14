using ELibrary.Contractor.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Contractor.DataContext
{
	public class ContractorDbContext : DbContext
	{
		public ContractorDbContext() { }
        public ContractorDbContext(DbContextOptions options) : base(options) { }
		public DbSet<ContractorOperation> Operations { get; set; }
		public DbSet<ContractorLibrary> Libraries { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ContractorOperation>()
				.HasOne(e => e.ContractorLibrary)
				.WithMany();
			builder.Entity<ContractorLibrary>()
				.HasAlternateKey(e => new { e.ContractorId, e.LibraryId });
		}
	}
}
