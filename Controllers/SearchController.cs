namespace ChuckSwapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var results = await searchService.SearchAsync(query);
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

    }
}
