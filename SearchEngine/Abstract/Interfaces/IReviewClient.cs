using SearchEngine.Code.Models;

namespace SearchEngine.Abstract.Interfaces;

public interface IReviewClient
{
    public Task<IEnumerable<Review>> GetFilmReview(Int32 filmId);
}
