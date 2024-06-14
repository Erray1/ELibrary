using ELibrary.Catalog.Application;
using ELibrary.Catalog.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CatalogDbContext>(conf =>
{
	conf.UseNpgsql(builder.Configuration.GetConnectionString("Db"));
});
builder.Services.AddMassTransit(conf =>
{
	conf.UsingInMemory();
	conf.AddConsumers(typeof(Program).Assembly);
});
builder.Services.AddCatalogServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
