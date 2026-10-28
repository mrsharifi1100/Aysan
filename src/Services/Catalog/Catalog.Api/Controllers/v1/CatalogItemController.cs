using Catalog.Application.Features.Catalog.CreateCatalogItem.Command;
using Catalog.Application.Features.Catalog.UpdateCatalogItem.Command;
using Catalog.Application.Features.Catalog.UpdateCatalogItemPrice.Handler;

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
        [HttpGet("Find{id}")]
        public async Task<IActionResult> GetCatalogDetail(int id)
        {
            var catalogItems = await _mediator.Send(new GetCatalogItemDetailQuery(id));
            return Ok(catalogItems);
        }
        [HttpPut("UpdateProductNameAndPrice")]
        public async Task<ActionResult> UpdateProductNameAndPrice([FromBody] UpdatePriceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCatalogItem([FromBody]CreateCatalogCommand command)
        {
            var catalogItemId = await _mediator.Send(command);
            return Ok(catalogItemId);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCatalogItem([FromBody]UpdateCatalogItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
