
namespace Catalog.Domain.AggregateModel.CatalogTypeAggregate;

public interface ICatalogTypeRepository: IRepository<CatalogType>
{
    CatalogType Add(CatalogType item);
    void Update(CatalogType item);
    Task<IEnumerable<CatalogType>> Get(long[] ids);
    Task<CatalogType> GetByIdAsync(long id);
}