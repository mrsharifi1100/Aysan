using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController(
    CatalogGrpcClientService catalogClient) : ControllerBase
    {
        [HttpGet("catalog-items")]
        public async Task<IActionResult> GetCatalogItems(
            CancellationToken cancellationToken)
        {
            var response = await catalogClient.GetAllCatalogItemsAsync(
                cancellationToken);

            return Ok(response);
        }
    }
}
