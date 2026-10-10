namespace Catalog.Domain.AggregateModel.CatalogItemAggregate;

public interface ICatalogItemRepository: IRepository<CatalogItem>
{
    CatalogItem Add(CatalogItem item);
    void Update(CatalogItem item);
    Task<IEnumerable<CatalogItem>> Get(long[] ids);
    Task<CatalogItem> GetByIdAsync(long id);
    Task<IEnumerable<CatalogItem>> GetByPagingAsync(int pageSize, int PageIndex);
}