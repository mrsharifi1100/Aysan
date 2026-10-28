
namespace Catalog.Application.DomainEventHandler.ProductPriceChanged;

public class ProductPriceChangedEventHandler
    : INotificationHandler<ProductPriceChangedDomainEvent>
{
    private readonly ILogger<ProductPriceChangedEventHandler> _logger;

    public ProductPriceChangedEventHandler(
        ILogger<ProductPriceChangedEventHandler> logger)
    {
        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task Handle(
        ProductPriceChangedDomainEvent notification,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Product price changed. CatalogId: {CatalogId}, OldPrice: {OldPrice}, NewPrice: {NewPrice}",
            notification.CatalogItem?.Id,
            notification.OldPrice,
            notification.NewPrice);

        return Task.CompletedTask;
    }
}