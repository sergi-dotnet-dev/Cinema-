using Nancy;
using ReviewService.Abstract.Interfaces;
using ReviewService.Code.Models;

namespace ReviewService.Code.Modules;

public class ReviewModule : NancyModule
{
    public ReviewModule(IReviewStore reviewStore, IEventSender eventSender) : base("/review")
    {
        Post("/{userid:int}&{filmid:int}/message", async (parameters, _) =>
        {
            var reviewContent = (String)parameters.message;
            var userId = (Int32)parameters.userid;
            var filmId = (Int32)parameters.filmid;

            await reviewStore.SaveAsync(new Review() { Content = reviewContent, FilmId = filmId, UserId = userId });
            await eventSender.Raise("Review. action_type:addition", userId, "raised by: ");
            return null;
        });
        Get("/{filmId:int}", parameters =>
        {
            var filmId = (Int32)parameters.filmid;
            var reviewList = reviewStore.Get(filmId);
            return Response.AsJson(reviewList);
        });
    }
}
