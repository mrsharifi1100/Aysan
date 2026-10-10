namespace Catalog.Application.Features.Catalog.UpdateCatalogType.Handler;

public class UpdateCatalogTypeCommandHandler : IRequestHandler<UpdateCatalogTypeCommand>
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public UpdateCatalogTypeCommandHandler(ICatalogTypeRepository catalogTypeRepository)
    {
        _catalogTypeRepository = catalogTypeRepository;
    }

    public async Task Handle(UpdateCatalogTypeCommand request, CancellationToken cancellationToken)
    {
        var catalogType = await _catalogTypeRepository.GetByIdAsync(request.CatalogTypeId);

        catalogType.Update(type:request.Type);

        await _catalogTypeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}

