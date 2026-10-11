namespace Catalog.Application.Features.Catalog.GetAllCatalogItem.Vm;
public class CatalogItemListVm
{
    public long TotalCount { get; set; }
    public IEnumerable<CatalogItemLists> Data { get; set; }
}

public class CatalogItemLists
{
    public int Id { get; set; }
    public string CatalogTypeName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public bool IsDiscount { get; set; }
    public string Name { get; set; }
    public int AvailableStock { get; set; }
}
