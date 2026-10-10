
namespace Catalog.Application.Features.Catalog.CreateCatalogItem.Command;

public sealed record CreateCatalogCommand(
    string Name,
    decimal Price,
    string Description,
    bool IsDiscount,
    long CatalogTypeId,
    int AvailableStock,
    int StockThreshold,
    int MaxStockThreshold
) : IRequest<long>;
