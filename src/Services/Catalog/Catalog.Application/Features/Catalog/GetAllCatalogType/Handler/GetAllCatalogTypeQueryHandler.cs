using Catalog.Application.Features.Catalog.GetAllCatalogType.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Features.Catalog.GetAllCatalogType.Handler
{
    public class GetAllCatalogTypeQueryHandler : IRequestHandler<GetAllCatalogTypeQuery, CatalogTypeListVm>
    {
        private readonly ICatalogTypeReadRepository _catalogTypeReadRepository;

        public GetAllCatalogTypeQueryHandler(ICatalogTypeReadRepository catalogTypeReadRepository)
        {
            _catalogTypeReadRepository = catalogTypeReadRepository;
        }

        public async Task<CatalogTypeListVm> Handle(GetAllCatalogTypeQuery request, CancellationToken cancellationToken)
        {
            return await _catalogTypeReadRepository.GetAllCatalogTypes();
        }
    }
}
