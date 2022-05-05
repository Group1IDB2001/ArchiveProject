using ArchiveLogic.Countries;
using ArchiveLogic.Items;
using ArchiveStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services  = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DbConnection"); // Add DbContext
services.AddDbContext<ArchiveContext>(param => param.UseSqlServer(connectionString));

services.AddScoped<IAuthorManager, AuthorManager>();
services.AddScoped<ICountryManager, CountryManager>();
services.AddScoped<IItemManager, ItemManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
