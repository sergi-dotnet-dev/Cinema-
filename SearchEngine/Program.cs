using Microsoft.EntityFrameworkCore;
using SearchEngine.Abstract.Infrastructure;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.DAL;

var _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SearchEngineBoundedContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IEventSender, EventSender>();
builder.Services.AddTransient<IActorClient, ActorClient>();
builder.Services.AddTransient<IReviewClient, ReviewClient>();
builder.Services.AddTransient<IFilmStore, FilmStore>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Search}/{action=FilmList}/{filmId?}");
});
app.Run();