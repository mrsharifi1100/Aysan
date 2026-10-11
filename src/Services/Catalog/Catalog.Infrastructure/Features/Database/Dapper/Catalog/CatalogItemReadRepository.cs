


namespace Catalog.Infrastructure.Features.Database.Dapper.Catalog
{
    public class CatalogItemReadRepository: ICatalogItemReadRepository
    {
        private readonly CatalogOptions _catalogOption;

        public CatalogItemReadRepository(IOptions<CatalogOptions> catalogOption)
        {
            _catalogOption = catalogOption.Value;
        }
        public async Task<CatalogItemListVm> GetAllCatalogItems()
        {
            using (var connection = new SqlConnection(_catalogOption.DefaultConnection))
            {
                connection.Open();

                var catalogItemListVm = new CatalogItemListVm();

                catalogItemListVm.TotalCount = await connection.QuerySingleAsync<long>(@"SELECT COUNT(*) FROM CatalogItem");

                catalogItemListVm.Data =
                    (await connection.QueryAsync<CatalogItemLists>(@"
                    SELECT
                        ci.Id AS Id,
                        ct.Type AS CatalogTypeName,
                        ci.Description AS Description,
                        ci.Price AS Price,
                        0 AS Discount,
                        ci.IsDiscount AS IsDiscount,
                        ci.Name AS Name,
                        ci.AvailableStock AS AvailableStock
                    FROM CatalogItem ci
                    INNER JOIN CatalogType ct
                        ON ci.CatalogTypeId = ct.Id
                    ORDER BY ci.Id DESC"))
                    .ToList();

                return catalogItemListVm;

            }

        }
        public async Task<CatalogItemDetail?> GetCatalogItemById(long id)
        {
            using var connection = new SqlConnection(_catalogOption.DefaultConnection);

            const string sql = """
        SELECT
            ci.Id AS Id,
            ct.Type AS CatalogTypeName,
            ci.Description AS Description,
            ci.Price AS Price,
            0 AS Discount,
            ci.IsDiscount AS IsDiscount,
            ci.Name AS Name,
            ci.AvailableStock AS AvailableStock
        FROM CatalogItem ci
        INNER JOIN CatalogType ct
            ON ci.CatalogTypeId = ct.Id
        WHERE ci.Id = @Id; 
        """;

            return await connection.QuerySingleOrDefaultAsync<CatalogItemDetail>(
                sql,
                new { Id = id });
        }

    }
}
