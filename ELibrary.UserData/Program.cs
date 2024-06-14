using ELibrary.UserData.DataContext;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserDataDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("Db"));
});
builder.Services.AddMassTransit(conf =>
{
	conf.UsingInMemory();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
