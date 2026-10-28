using Catalog.Application.Features.Catalog.Exceptions.CatalogItem;
using Catalog.Application.Features.Catalog.UpdateCatalogItemPrice.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Features.Catalog.UpdateCatalogItemPrice.Command;

public class UpdatePriceCommandHandler
    : IRequestHandler<UpdatePriceCommand>
{
    private readonly ICatalogItemRepository _catalogRepository;
    private readonly ILogger<UpdatePriceCommandHandler> _logger;

    public UpdatePriceCommandHandler(
        ICatalogItemRepository catalogRepository,
        ILogger<UpdatePriceCommandHandler> logger)
    {
        _catalogRepository = catalogRepository
            ?? throw new ArgumentNullException(nameof(catalogRepository));

        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(
        UpdatePriceCommand request,
        CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogRepository.GetByIdAsync(request.Id);

        if (catalogItem == null)
        {
            throw new CatalogNotFoundException(request.Id);
        }

        catalogItem.UpdateName(request.Name);
        catalogItem.UpdatePrice(request.Price);

        await _catalogRepository.UnitOfWork.SaveEntitiesAsync();

        _logger.LogInformation(
            "----- Catalog Price Update - Catalog: {@Catalog}",
            catalogItem);
    }
}