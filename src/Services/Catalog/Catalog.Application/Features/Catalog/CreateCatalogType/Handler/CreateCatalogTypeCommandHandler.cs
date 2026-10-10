namespace Catalog.Application.Features.Catalog.CreateCatalogType.Handler;

public class CreateCatalogTypeCommandHandler : IRequestHandler<CreateCatalogTypeCommand,long>
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CreateCatalogTypeCommandHandler(ICatalogTypeRepository catalogTypeRepository)
    {
        _catalogTypeRepository = catalogTypeRepository;
    }

    public async Task<long> Handle(CreateCatalogTypeCommand request, CancellationToken cancellationToken)
    {
        CatalogType catalogType = new CatalogType(type:request.Type);

        _catalogTypeRepository.Add(catalogType);

        await _catalogTypeRepository.UnitOfWork.SaveEntitiesAsync();

        return catalogType.Id;
    }
}

