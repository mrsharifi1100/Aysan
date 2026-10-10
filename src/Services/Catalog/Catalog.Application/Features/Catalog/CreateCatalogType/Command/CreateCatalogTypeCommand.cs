namespace Catalog.Application.Features.Catalog.CreateCatalogType.Command;

public sealed record CreateCatalogTypeCommand(string? Type) : IRequest<long>;