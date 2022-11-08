using Newtonsoft.Json;
using Polly;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.Code.Models;

namespace SearchEngine.Abstract.Infrastructure;

public class ReviewClient : IReviewClient
{
    private static AsyncPolicy _exponentialRetryPolicy = Policy
         .Handle<Exception>()
         .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));
    private static async Task<HttpResponseMessage> RequestReviewFromReviewService(Int32 filmId)
    {
        var reviewResource = String.Format($"/Review/GetReview?filmId={filmId}");
        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(@"https://localhost:7287");
            return await httpClient.GetAsync(reviewResource).ConfigureAwait(false);
        }
    }
    private static async Task<IEnumerable<Review>> ConvertToReviewAsync(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var reviews = JsonConvert.DeserializeObject<List<Review>>
            (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        return reviews.Select(p => new Review() { Content = p.Content.ToString(), UserId = p.UserId });
    }
    private static async Task<IEnumerable<Review>> GetItemsFromReviewServiceAsync(Int32 filmId)
    {
        var response = await RequestReviewFromReviewService(filmId).ConfigureAwait(false);
        return await ConvertToReviewAsync(response).ConfigureAwait(false);
    }
    public async Task<IEnumerable<Review>> GetFilmReview(Int32 filmId)
        => await _exponentialRetryPolicy.ExecuteAsync(async () => await GetItemsFromReviewServiceAsync(filmId).ConfigureAwait(false));
}