using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Features.Catalog.GetCatalogItem.Vm;

public class CatalogItemDetail
{
    public long Id { get; set; }
    public string CatalogTypeName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public bool IsDiscount { get; set; }
    public string Name { get; set; }
    public int AvailableStock { get; set; }
}

