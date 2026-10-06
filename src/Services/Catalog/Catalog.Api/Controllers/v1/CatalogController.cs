namespace Catalog.Api.Controllers.v1
{
    
    public class CatalogController : ApiVersionOneController
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCatalogs()
        {
            _logger.LogInformation("hi every one");
            return Ok("hello catalog");
        }
    }
}
