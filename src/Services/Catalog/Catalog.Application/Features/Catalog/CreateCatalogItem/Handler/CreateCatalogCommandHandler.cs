using Catalog.Application.Features.Catalog.Exceptions.CatalogItem;

namespace Catalog.Application.Features.Catalog.CreateCatalogItem.Handler;

public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, long>
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CreateCatalogCommandHandler(ICatalogItemRepository catalogItemRepository)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task<long> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
        bool exists = await _catalogItemRepository.ExistsByNameAsync(
        request.Name,
        cancellationToken);

        if (exists)
        {
            throw new CatalogItemAlreadyExistsException(request.Name);
        }
        CatalogItem catalogItem = new CatalogItem(
            name: request.Name,
            price: request.Price,
            description: request.Description,
            isDiscount: request.IsDiscount,
            catalogTypeId: request.CatalogTypeId,
            availableStock: request.AvailableStock,
            stockThreshold: request.StockThreshold,
            maxStockThreshold: request.MaxStockThreshold);

        _catalogItemRepository.Add(catalogItem);

        await _catalogItemRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);

        return catalogItem.Id;
    }
}

