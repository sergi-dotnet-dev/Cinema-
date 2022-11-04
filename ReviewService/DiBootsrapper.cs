using Microsoft.EntityFrameworkCore;
using Nancy;
using Nancy.TinyIoc;
using ReviewService.Abstract.Infrastructure;
using ReviewService.Abstract.Interfaces;
using ReviewService.DAL;

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
        var _context = new ReviewBoundedContext(_configuration.GetConnectionString("Default"));
        container.Register<ReviewBoundedContext>(_context);
    }
    protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
    {
        container.Register<IReviewStore, ReviewStore>().AsMultiInstance();
        container.Register<IEventSender, EventSender>().AsMultiInstance();
    }
}