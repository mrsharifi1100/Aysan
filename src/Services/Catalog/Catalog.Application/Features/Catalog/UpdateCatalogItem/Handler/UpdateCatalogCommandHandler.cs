namespace Catalog.Application.Features.Catalog.UpdateCatalogItem.Handler;

public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogItemCommand>
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public UpdateCatalogCommandHandler(ICatalogItemRepository catalogItemRepository)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogItemRepository.GetByIdAsync(request.CatalogItemId);

        catalogItem.Update(
        name: request.Name,
        price: request.Price,
        description: request.Description,
        isDiscount: request.IsDiscount,
        catalogTypeId: request.CatalogTypeId,
        availableStock: request.AvailableStock,
        stockThreshold: request.StockThreshold,
        maxStockThreshold: request.MaxStockThreshold
        );

        _catalogItemRepository.Update(catalogItem);

        await _catalogItemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}