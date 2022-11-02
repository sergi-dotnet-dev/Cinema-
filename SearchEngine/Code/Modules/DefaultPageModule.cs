using Nancy;

namespace SearchEngine.Code.Modules;

public class DefaultPageModule : NancyModule
{
    public DefaultPageModule() : base("/")
    {
        Get("", _ => View["Index.html"]);
    }
}
