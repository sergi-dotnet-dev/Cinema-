using Microsoft.EntityFrameworkCore;
using Nancy;
using Nancy.TinyIoc;
using SearchEngine.Abstract.Infrastructure;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.DAL;
using System.Runtime.CompilerServices;

namespace SearchEngine;

public class DiBootsrapper : DefaultNancyBootstrapper
{
    public IConfiguration _configuration;

    public DiBootsrapper()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }
    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    {
        container.Register(_configuration);
        var _context = new SearchEngineBoundedContext(_configuration.GetConnectionString("Default"));
        container.Register<SearchEngineBoundedContext>(_context);
    }
    protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
    {
        container.Register<IFilmStore, FilmStore>().AsMultiInstance();
        //container.Register<IEventHandler, >();
    }
}