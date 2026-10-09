namespace Catalog.Domain.AggregateModel.CatalogTypeAggregate;

public class CatalogType : Entity, IAggregateRoot
{
    public CatalogType(string? type)
    {
        ValidateType(type);
        Type = type;
    }
    public string? Type {  get; private set; }
    private static void ValidateType(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CatalogDomainException($"Catalog Type {name} cannot be empty.");

        if (name.Length > 30)
        {
            throw new CatalogDomainException(
                $"CatalogType {name} cannot be longer than 30 characters.");
        }
    }
}
