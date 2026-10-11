
namespace Catalog.Application.Features.Catalog.GetAllCatalogItem.Handler;

public class GetAllCatalogItemQueryHandler : IRequestHandler<GetAllCatalogItemQuery, CatalogItemListVm>
{
    private readonly ICatalogItemReadRepository _catalogItemReadRepository;

    public GetAllCatalogItemQueryHandler(ICatalogItemReadRepository catalogItemReadRepository)
    {
        _catalogItemReadRepository = catalogItemReadRepository;
    }

    public async Task<CatalogItemListVm> Handle(GetAllCatalogItemQuery request, CancellationToken cancellationToken)
    {
        return await _catalogItemReadRepository.GetAllCatalogItems();
    }
}

