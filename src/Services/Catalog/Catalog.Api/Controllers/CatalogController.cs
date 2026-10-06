
namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCatalogs()
        {
            return Ok("hello catalog");
        }
    }
}
