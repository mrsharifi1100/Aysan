namespace Catalog.Infrastructure.Features.Database.Dapper.Catalog
{
    public class CatalogTypeReadRepository:ICatalogTypeReadRepository
    {
        private readonly CatalogOptions _catalogOption;

        public CatalogTypeReadRepository(IOptions<CatalogOptions> catalogOption)
        {
            _catalogOption = catalogOption.Value;
        }
        public async Task<CatalogTypeListVm> GetAllCatalogTypes()
        {
            using (var connection = new SqlConnection(_catalogOption.DefaultConnection))
            {
                connection.Open();

                var catalogListVm = new CatalogTypeListVm();

                catalogListVm.TotalCount = await connection.QuerySingleAsync<long>(@"SELECT COUNT(*) FROM CatalogType");

                catalogListVm.Data =
                    (await connection.QueryAsync<CatalogTypeList>(@"
                    SELECT
                        Id AS Id,
                        Type AS Type
                    FROM CatalogType"))
                    .ToList();

                return catalogListVm;

            }
        }
    }
}
