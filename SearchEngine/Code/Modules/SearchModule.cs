using Nancy;
using Nancy.ModelBinding;
using SearchEngine.Abstract.Interfaces;

namespace SearchEngine.Code.Modules;

public class SearchModule : NancyModule
{
    public SearchModule(IFilmStore filmStore/*, IEventHandler eventHandler*/) : base("/search")
    {
       
        Get("/{substring}", parameters =>
            {
                var subString = (String)parameters.substring;
                var films = filmStore.Get(subString);
                return View["SearchResultView", films];
            });
        Get("/{categories}", parameters =>
        {
            var categories = this.Bind<Int32[]>();
            var films = filmStore.Get(categories);
            return View["SearchResultView", films];
        });
    }
}
