using ChuckSwapi.ViewModels;

namespace ChuckSwapi.Services
{
    public class StarWarsService : IStarWarsService
    {
        private readonly IHttpClientFactory httpClientFactory;
        const string StarWarsUrl = "https://swapi.dev/api/people/";
        public StarWarsService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            var url = StarWarsUrl + id;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var person =  JsonConvert.DeserializeObject<Person>(content);
                return person;
            }
            return null;
        }

        public async Task<PeopleVm> GetAllPeopleAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, StarWarsUrl);

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var people = JsonConvert.DeserializeObject<PeopleVm>(content);
                return people;
            }
            return null;
        }

        public async Task<PeopleVm> GetPeopleAsync(string url)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var people = JsonConvert.DeserializeObject<PeopleVm>(content);
                return people;
            }
            return null;
        }
    }
}
