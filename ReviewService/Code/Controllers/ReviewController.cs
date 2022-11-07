using Microsoft.AspNetCore.Mvc;
using ReviewService.Abstract.Interfaces;
using ReviewService.Code.Models;

namespace ReviewService.Code.Controllers;
public class ReviewController : Controller
{
    private readonly IReviewStore _reviewStore;
    private readonly IEventSender _eventSender;

    public ReviewController(IReviewStore reviewStore, IEventSender eventSender)
    {
        _reviewStore = reviewStore;
        _eventSender = eventSender;
    }

    [HttpGet]
    public IActionResult GetReview(Int32 filmId)
    {
        var response = _reviewStore.Get(filmId);
        return Json(response);
    }
    [HttpPost]
    public IActionResult AddReview(Review review)
    {
        _reviewStore.SaveAsync(review);
        _eventSender.Raise("testraise", review.UserId, "testraise");
        return null;
    }
}
