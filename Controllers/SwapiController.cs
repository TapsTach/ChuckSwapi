namespace ChuckSwapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SwapiController :ControllerBase
    {
        private readonly IStarWarsService starWarsService;

        public SwapiController(IStarWarsService starWarsService)
        {
            this.starWarsService = starWarsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var person = await starWarsService.GetPersonAsync(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var people = await starWarsService.GetAllPeopleAsync();
            return Ok(people);
        }
        [HttpPost(nameof(GetPeople))]
        public async Task<IActionResult> GetPeople([FromBody]GetPeopleVm vm)
        {
            var people = await starWarsService.GetPeopleAsync(vm.Url);
            return Ok(people);
        }
    }
}
