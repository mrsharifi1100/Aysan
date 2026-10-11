
namespace Catalog.Application.Features.Catalog.GetCatalogItem.Query;

public record GetCatalogItemDetailQuery(long id) : IRequest<CatalogItemDetail>;