using Microsoft.AspNetCore.Server.Kestrel.Core;
using Nancy.Owin;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
var app = builder.Build();

app.UseOwin(buildFunc =>
{
    buildFunc(next => env =>
    {
        var context = new LibOwin.OwinContext(env);
        var method = context.Request.Method;
        var path = context.Request.Path;
        Console.WriteLine($"Got request: {method} {path}");
        return next(env);
    });
    buildFunc.UseNancy();
});

app.Run();