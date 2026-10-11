namespace Catalog.Application.Features.Catalog;

public interface ICatalogItemReadRepository
{
    Task<CatalogItemListVm> GetAllCatalogItems();
    Task<CatalogItemDetail?> GetCatalogItemById(long id);
}