namespace ChuckSwapi.ViewModels
{
    public class PeopleVm
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Person> Results { get; set; }
        
    }
}
