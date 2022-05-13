
namespace ChuckSwapi.Services
{
    public interface IChuckNorrisService
    {
        Task<List<string>> GetCategoriesAsync();
        Task<Joke> GetRandomJokeAsync(string category);
    }
}