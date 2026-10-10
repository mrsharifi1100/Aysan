namespace Catalog.Domain.Common;

public interface IRepository<T>
{
    IUnitOfWork UnitOfWork { get; }
}