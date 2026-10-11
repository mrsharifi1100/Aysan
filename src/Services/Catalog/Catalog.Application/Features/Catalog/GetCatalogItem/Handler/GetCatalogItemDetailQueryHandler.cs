using Catalog.Application.Features.Catalog.GetCatalogItem.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Features.Catalog.GetCatalogItem.Handler;

public class GetCatalogItemDetailQueryHandler : IRequestHandler<GetCatalogItemDetailQuery, CatalogItemDetail>
{
    private readonly ICatalogItemReadRepository _catalogItemReadRepository;

    public GetCatalogItemDetailQueryHandler(ICatalogItemReadRepository catalogItemReadRepository)
    {
        _catalogItemReadRepository = catalogItemReadRepository;
    }

    public async Task<CatalogItemDetail> Handle(GetCatalogItemDetailQuery request, CancellationToken cancellationToken)
    {
        var catalogItem = await _catalogItemReadRepository.GetCatalogItemById(request.id);
        return catalogItem;
    }
}

