using Nancy;
using ReviewService.Code.Models;

namespace ReviewService.Abstract.Interfaces;

public interface IReviewStore
{
    public Task SaveAsync(Review review);
    public IEnumerable<Review> Get(Int32 filmId);
}
