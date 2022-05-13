
namespace ChuckSwapi.Services
{
    public interface ISearchService
    {
        Task<SearchResultsVm> SearchAsync(string text);
    }
}