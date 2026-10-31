namespace Discount.API.Grpc;

public class CatalogGrpcClientService(
    CatalogGrpc.CatalogGrpcClient client)
{
    public async Task<CatalogItemListResponse> GetAllCatalogItemsAsync(
        CancellationToken cancellationToken = default)
    {
        return await client.GetAllCatalogItemsAsync(
            new GetAllCatalogItemsRequest(),
            cancellationToken: cancellationToken);
    }
}