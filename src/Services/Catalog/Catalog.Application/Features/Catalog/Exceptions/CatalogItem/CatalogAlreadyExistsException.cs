namespace Catalog.Application.Features.Catalog.Exceptions.CatalogItem;

public sealed class CatalogItemAlreadyExistsException : Exception
{
    public CatalogItemAlreadyExistsException(string name)
        : base($"Catalog item with name '{name}' already exists.")
    {
    }
}