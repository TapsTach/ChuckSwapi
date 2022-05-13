namespace ChuckSwapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ChuckController : ControllerBase
    {
        private readonly IChuckNorrisService chuckService;

        public ChuckController(IChuckNorrisService chuckService)
        {
            this.chuckService = chuckService;
        }

        [HttpGet(nameof(GetCategories))]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await chuckService.GetCategoriesAsync();
            if(categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet(nameof(GetRandomJoke))]
        public async Task<IActionResult> GetRandomJoke(string category)
        {
            var categories = await chuckService.GetRandomJokeAsync(category);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

    }
}
