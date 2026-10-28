using Catalog.Domain.Events;

namespace Catalog.Domain.AggregateModel.CatalogItemAggregate;

public class CatalogItem : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string? Description { get; private set; }
    public bool IsDiscount { get; private set; }

    public int AvailableStock { get; private set; }
    public int StockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }

    public long CatalogTypeId { get; private set; }

    public CatalogType CatalogType { get; private set; }

    public CatalogItem(
        string name,
        decimal price,
        string? description,
        bool isDiscount,
        long catalogTypeId,
        int availableStock,
        int stockThreshold,
        int maxStockThreshold)
    {
        ValidateName(name);

        Name = name;
        Price = price;
        Description = description;
        IsDiscount = isDiscount;
        CatalogTypeId = catalogTypeId;
        AvailableStock = availableStock;
        StockThreshold = stockThreshold;
        MaxStockThreshold = maxStockThreshold;
    }
    public void Update(
        string name,
        decimal price,
        string? description,
        bool isDiscount,
        long catalogTypeId,
        int availableStock,
        int stockThreshold,
        int maxStockThreshold)
    {
        ValidateName(name);
        Name = name;
        Price = price;
        Description = description;
        IsDiscount = isDiscount;
        CatalogTypeId = catalogTypeId;
        AvailableStock = availableStock;
        StockThreshold = stockThreshold;
        MaxStockThreshold = maxStockThreshold;
    }
    public void UpdateName(string newName)
    {
        this.Name = newName ?? throw new CatalogDomainException("The name is empty and must be entered");
    }
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new CatalogDomainException("The price must be than 0.");

        if (newPrice != this.Price)
        {
            // raise Event for Price Changed
            AddDomainEvent(new ProductPriceChangedDomainEvent(newPrice, Price, this));

        }

        this.Price = newPrice;

    }
    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CatalogDomainException($"Catalog Item {name} cannot be empty.");

        if (name.Length > 30)
        {
            throw new CatalogDomainException(
                $"Catalog Item {name} cannot be longer than 30 characters.");
        }
    }
}

