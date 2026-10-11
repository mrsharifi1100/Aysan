
namespace Catalog.Api.Controllers.v1
{
    public class CatalogTypeController : ApiVersionOneController
    {
        private readonly IMediator _mediator;

        public CatalogTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCatalogTypes()
        {
            var catalogTypes = await _mediator.Send(new GetAllCatalogTypeQuery());
            return Ok(catalogTypes);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCatalogType([FromBody] CreateCatalogTypeCommand command)
        {
            var catalogTypeId = await _mediator.Send(command);
            return Ok(catalogTypeId);
        }
    }
}
