using ReviewService.Abstract.Interfaces;
using ReviewService.Code.Models;
using ReviewService.DAL;

namespace ReviewService.Abstract.Infrastructure;

public class ReviewStore : IReviewStore
{
    private readonly ReviewBoundedContext _context;

    public ReviewStore(ReviewBoundedContext context) => _context = context;

    public IEnumerable<Review> Get(Int32 filmId)
    {
        return _context.Reviews
            .Where(r => r.FilmId == filmId)
            .ToList();
    }

    public async Task SaveAsync(Review review)
    {
        using (_context)
        {
            //check review policy
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}