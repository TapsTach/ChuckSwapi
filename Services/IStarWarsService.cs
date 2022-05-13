
using ChuckSwapi.ViewModels;

namespace ChuckSwapi.Services
{
    public interface IStarWarsService
    {
        Task<PeopleVm> GetAllPeopleAsync();
        Task<PeopleVm> GetPeopleAsync(string url);
        Task<Person> GetPersonAsync(int id);
    }
}