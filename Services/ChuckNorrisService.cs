namespace ChuckSwapi.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly IHttpClientFactory httpClientFactory;
        const string ChuckApi = "https://api.chucknorris.io/jokes/";
        public ChuckNorrisService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            var url = ChuckApi + "categories";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var jokes = JsonConvert.DeserializeObject<List<string>>(content);
                return jokes;
            }
            return null;
        }
        public async Task<Joke> GetRandomJokeAsync(string category)
        {
            var url = $"https://api.chucknorris.io/jokes/random?category={category}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var jokes = JsonConvert.DeserializeObject<Joke>(content);
                return jokes;
            }
            return null;
        }
    }
}
