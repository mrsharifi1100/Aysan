namespace Catalog.Application.Features.Catalog.Exceptions.CatalogItem;

public sealed class CatalogNotFoundException : Exception
{
    public CatalogNotFoundException(long id)
        : base($"Catalog item with id '{id}' was not found.")
    {
    }
}