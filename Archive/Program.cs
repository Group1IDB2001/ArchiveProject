using ArchiveLogic;
using ArchiveLogic.CollectionItems;
using ArchiveLogic.Collections;
using ArchiveLogic.Countries;
using ArchiveLogic.IItemLanguage;
using ArchiveLogic.Items;
using ArchiveLogic.ItemsAuthors;
using ArchiveLogic.Likes;
using ArchiveLogic.LLanguage;
using ArchiveLogic.Qestions;
using ArchiveLogic.Reactions;
using ArchiveLogic.Responses;
using ArchiveLogic.Saves;
using ArchiveLogic.Tag;
using ArchiveLogic.TtagItems;
using ArchiveLogic.Users;
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
services.AddScoped<IItemAuthorManager, ItemAuthorManager>();
services.AddScoped<ILanguageManager, LanguageManager>();
services.AddScoped<IItemLanguageManager, ItemLanguageManager>();
services.AddScoped<ITtagManager, TtagManager>();
services.AddScoped<IUserManager, UserManager>();
services.AddScoped<ITtagItemManager, TtagItemManager>();
services.AddScoped<ICollectionManager, CollectionManager>();
services.AddScoped<ICollectionItemManager, CollectionItemManager>();
services.AddScoped<ILikeManager, LikeManager>();
services.AddScoped<IQestionManager, QestionManager>();
services.AddScoped<IReactionManager, ReactionManager>();
services.AddScoped<IResponseManager, ResponseManager>();
services.AddScoped<ISaveManager, SaveManager>();


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
    pattern: "{controller=Items}/{action=Index}/{id?}");

app.Run();
