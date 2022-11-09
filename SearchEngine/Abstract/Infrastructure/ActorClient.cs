using Newtonsoft.Json;
using Polly;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.Code.Models;

namespace SearchEngine.Abstract.Infrastructure;

public class ActorClient : IActorClient
{
    private static AsyncPolicy _exponentialRetryPolicy = Policy
         .Handle<Exception>()
         .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));
    private static async Task<HttpResponseMessage> RequestActorFromService(Int32 filmId)
    {
        var actorResource = String.Format($"/actor/getactorlist?filmId={filmId}");
        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(@"https://localhost:7136");
            return await httpClient.GetAsync(actorResource).ConfigureAwait(false);
        }
    }
    private static async Task<IEnumerable<Actor>> ConvertToActorAsync(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var actors = JsonConvert.DeserializeObject<List<Actor>>
            (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        return actors.Select(p => new Actor() { Id = p.Id, BornYear = p.BornYear, Name = p.Name, Photo = p.Photo });
    }
    private static async Task<IEnumerable<Actor>> GetItemsFromActorServiceAsync(Int32 filmId)
    {
        var response = await RequestActorFromService(filmId).ConfigureAwait(false);
        return await ConvertToActorAsync(response).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Actor>> GetFilmActor(Int32 filmId) =>
        await _exponentialRetryPolicy.ExecuteAsync(async () => await GetItemsFromActorServiceAsync(filmId).ConfigureAwait(false));
}