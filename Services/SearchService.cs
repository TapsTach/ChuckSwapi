
namespace ChuckSwapi.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory httpClientFactory;
        const string StarWarsUrl = "https://swapi.dev/api/people/?search=";
        const string ChuckApi = "https://api.chucknorris.io/jokes/search?query=";
        public SearchService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<SearchResultsVm> SearchAsync(string text)
        {
            var result = new SearchResultsVm();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, StarWarsUrl + text);

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                result.People = JsonConvert.DeserializeObject<PeopleVm>(content).Results;
            }

            await SearchJokesAsync(result, text);

            return result;
        }

        private async Task SearchJokesAsync(SearchResultsVm result, string text)
        {
            var httpClient = httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, ChuckApi + text);
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                result.Jokes = JsonConvert.DeserializeObject<JokesVm>(content).Result;
            }
        }
    }
}
