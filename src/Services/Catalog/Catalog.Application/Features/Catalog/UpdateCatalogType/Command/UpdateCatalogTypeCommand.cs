namespace Catalog.Application.Features.Catalog.UpdateCatalogType.Command;

public sealed record UpdateCatalogTypeCommand(long CatalogTypeId,string? Type) : IRequest;

