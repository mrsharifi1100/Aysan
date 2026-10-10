namespace Catalog.Application.Features.Catalog.UpdateCatalogItem.Command;

public sealed record UpdateCatalogItemCommand(
    long CatalogItemId,
    string Name,
    decimal Price,
    string Description,
    bool IsDiscount,
    long CatalogTypeId,
    int AvailableStock,
    int StockThreshold,
    int MaxStockThreshold
) : IRequest;
