using Microsoft.EntityFrameworkCore;
using ActorService.Abstract.Interfaces;
using ActorService.DAL;
using ActorService.Abstract.Infrastructure;

var _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ActorBoundedContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IEventSender, EventSender>();
builder.Services.AddTransient<IActorStore, ActorStore>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action}");
});
app.Run();