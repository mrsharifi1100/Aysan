namespace Catalog.Api.Controllers.v1
{
    
    public class CatalogController : ApiVersionOneController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCatalogs()
        {
            return Ok("hello catalog");
        }
    }
}
