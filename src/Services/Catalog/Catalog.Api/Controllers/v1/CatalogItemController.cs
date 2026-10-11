



namespace Catalog.Api.Controllers.v1
{
    
    public class CatalogItemController : ApiVersionOneController
    {
        private readonly IMediator _mediator;
        public CatalogItemController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCatalogItems()
        {
            var catalogItems=await _mediator.Send(new GetAllCatalogItemQuery());
            return Ok(catalogItems); 
        }
        [HttpGet("CatalogTypes")]
        public async Task<IActionResult> GetAllCatalogTypes()
        {
            var catalogItems = await _mediator.Send(new GetAllCatalogTypeQuery());
            return Ok(catalogItems);
        }
        [HttpGet("Find{id}")]
        public async Task<IActionResult> GetCatalogDetail(int id)
        {
            var catalogItems = await _mediator.Send(new GetCatalogItemDetailQuery(id));
            return Ok(catalogItems);
        }
    }
}
