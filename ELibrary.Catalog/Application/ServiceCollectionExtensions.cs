namespace ELibrary.Catalog.Application
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCatalogServices(this IServiceCollection services)
		{
			services.AddScoped<BookRepository>();
			services.AddScoped<BookManager>();
			services.AddScoped<SearchEngine>();
			return services;
		}
	}
}
