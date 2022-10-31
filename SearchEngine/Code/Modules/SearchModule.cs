using Nancy;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.Code.Models;

namespace SearchEngine.Code.Modules;

public sealed class SearchModule : NancyModule
{
    public SearchModule(IFilmStore filmStore) : base("/search")
    {
        //Get("/", _ => View["Index.html"]);
        Get("/{substring}", parameters =>
            {
                var subString = (String)parameters.substring;
                var films = filmStore.Get(subString);
                return View["SearchResultView.html", films];
            });
        //Get("/{categories:int}", parameters =>
        //{
        //    var categories = this.Bind<Int32[]>();
        //    var films = filmStore.Get(categories);
        //    return View["SearchResultView", films];
        //});
        //Get("/{film}", parameters =>
        //{
        //    var film = (Film)parameters.film;
        //    return View["FilmInfoView", film];
        //});
    }
}
