using Microsoft.EntityFrameworkCore;
using ReviewService.Abstract.Infrastructure;
using ReviewService.Abstract.Interfaces;
using ReviewService.DAL;

var _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReviewBoundedContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IEventSender, EventSender>();
builder.Services.AddTransient<IReviewStore, ReviewStore>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoint=>
{
    endpoint.MapControllerRoute(name:"default",pattern: "{controller=Review}/{action=GetReview}/{filmId?}");
});
app.Run();