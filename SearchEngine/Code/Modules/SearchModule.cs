using Nancy;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.Code.Models;

namespace SearchEngine.Code.Modules;

public sealed class SearchModule : NancyModule
{
    public SearchModule(IFilmStore filmStore, IReviewClient reviewClient, IActorClient actorClient) : base("/search")
    {
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
        Get("/{filmId:int}", parameters =>
        {
            var filmId = (Int32)parameters.filmId;
            var concreteFilm = filmStore.Get(filmId).First();
            //this.ViewBag.reviews = reviewClient.GetFilmReview(filmId);
            //this.ViewBag.actors = actorClient.GetFilmActor(filmId);
            
            return View["FilmInfoView", concreteFilm];
        });
    }
}
