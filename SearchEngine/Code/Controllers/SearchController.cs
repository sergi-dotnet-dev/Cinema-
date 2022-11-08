using Microsoft.AspNetCore.Mvc;
using SearchEngine.Abstract.Interfaces;

namespace SearchEngine.Code.Controllers;
public class SearchController : Controller
{
    private readonly IFilmStore _filmStore;
    private readonly IReviewClient _reviewClient;
    private readonly IActorClient _actorclient;
    public SearchController(IFilmStore filmStore, IReviewClient reviewClient, IActorClient actorClient)
    {
        _filmStore = filmStore;
        _actorclient = actorClient;
        _reviewClient = reviewClient;
    }

    [HttpGet]
    public IActionResult FilmList(String subStr)
    {
        if (subStr is null || subStr == String.Empty)
        {
            subStr = "test";
            //return view (start page);
        }
        var films = _filmStore.Get(subStr);
        return View("SearchResultView", films);
    }
    //[HttpGet]
    //public IActionResult FilmList(Int32[] )
    //{

    //}
    [HttpGet]
    public async Task<IActionResult> ChoosenFilm(Int32 filmId)
    {
        if (filmId == 0)
        {
            filmId = 3;
            //return view(startpage);
        }
        var concreteFilm = _filmStore.Get(filmId);
        var filmReviews = await _reviewClient.GetFilmReview(filmId);
        ViewBag.reviews = filmReviews;
        return View("FilmInfoView", concreteFilm);
    }
}
