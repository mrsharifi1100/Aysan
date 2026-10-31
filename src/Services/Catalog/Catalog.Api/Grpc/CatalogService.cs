using Catalog.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Catalog.Api.Grpc;

public class CatalogGrpcService : CatalogGrpc.CatalogGrpcBase
{
    private readonly IMediator _mediator;

    public CatalogGrpcService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<CatalogItemListResponse> GetAllCatalogItems(
        GetAllCatalogItemsRequest request,
        ServerCallContext context)
    {
        var query = new GetAllCatalogItemQuery();

        var result = await _mediator.Send(
            query,
            context.CancellationToken);

        var response = new CatalogItemListResponse
        {
            TotalCount = result.TotalCount
        };

        foreach (var item in result.Data)
        {
            response.Data.Add(new CatalogItemResponse
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = (double)item.Price
            });
        }

        return response;
    }
}