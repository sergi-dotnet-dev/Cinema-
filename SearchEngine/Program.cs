using Microsoft.EntityFrameworkCore;
using Nancy.Owin;
using SearchEngine.Abstract.Infrastructure;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.DAL;

var _configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(_configuration);
builder.Services.AddDbContext<SearchEngineBoundedContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:Default"]));
builder.Services.AddTransient<IFilmStore, FilmStore>();
//builder.Services.AddTransient<IEventHandler, >
var app = builder.Build();

app.UseOwin(buildFunc =>
{
    buildFunc(next => env =>
    {
        Console.WriteLine("Got request");
        return next(env);
    });
    buildFunc.UseNancy();
});

app.Run();