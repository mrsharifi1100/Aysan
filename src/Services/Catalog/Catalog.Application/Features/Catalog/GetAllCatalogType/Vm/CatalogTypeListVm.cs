namespace Catalog.Application.Features.Catalog.GetAllCatalogType.Vm;
public class CatalogTypeListVm
{
    public long TotalCount { get; set; }
    public IEnumerable<CatalogTypeList> Data { get; set; }
}

public class CatalogTypeList
{
    public int Id { get; set; }
    public string Type { get; set; }
}
