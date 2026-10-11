namespace Catalog.Application.Features.Catalog;

public interface ICatalogTypeReadRepository
{
    Task<CatalogTypeListVm> GetAllCatalogTypes();
}